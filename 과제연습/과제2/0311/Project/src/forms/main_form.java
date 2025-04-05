package forms;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.Date;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextField;
import javax.swing.JTree;
import javax.swing.tree.DefaultMutableTreeNode;
import javax.swing.tree.TreePath;

import aframe.aframe;
import jdbc.db;
import jdbc.vq;

public class main_form extends aframe {
   JLabel jn[] = new JLabel[2];   
   JTree tree;   
   JButton jb[] = new JButton[2];
   String bn[] = "검색,로그인".split(",");   
   JButton jb1[] = new JButton[3];
   String bn1[] = "가격순(↓),가격순(↑),별점순(↓)".split(",");   
   String orderby = "", category = "";   
   int rno[];
   
   public main_form() {
      fs("메인");
      emp(pc, 10, 10, 0, 10);
      
      np.add(p0 = new JPanel(new FlowLayout(0, 20, 0)));
      p0.add(jl = new JLabel("ClothingStore"));
      ft(jl, 1, 30);
      p0.add(jt = new JTextField());
      sz(jt, 250, 30);
      for (int i = 0; i < jb.length; i++) {
         p0.add(jb[i] = new JButton(bn[i]));
         sz(jb[i], 80, 30);
         bl(jb[i]);
         int a = i;
         jb[i].addActionListener(e -> {
           if (a == 0) {
           if (jt.getText().equals("")) {
           category = "";
           orderby = "";
           }
           dUP();
           } else {
           new login_form();
           dispose();
           }
         });
      }
      emp(p0, 10, 0, 10, 0);
      
      np.add(p0 = new JPanel(new BorderLayout()), e);
      emp(p0, 0, 0, 15, 0);
      p0.add(img = new JLabel(), w);
      emp(img, 0, 0, 0, 10);
      p0.add(p1 = new JPanel(new GridLayout(0, 1)));
      for (int i = 0; i < jn.length; i++) {
         p1.add(jn[i] = new JLabel());
      }
      emp(p1, 5, 0, 5, 30);
      try {
         if (vq.uno != 0) {
            rs = db.execute("select * from user where u_no = " + vq.uno);
            if (rs.next()) {
               img.setIcon(blob(rs.getBinaryStream(7), 30, 30));
               jn[0].setText(rs.getString(4));
               jn[1].setText(def.format(rs.getInt(5)) + "원");
            }
            jb[1].setVisible(false);
            img.addMouseListener(new MouseAdapter() {
               @Override
                  public void mouseClicked(MouseEvent e) {
//                     new i관리();
                     dispose();
                  }
         });
         }
      } catch (Exception e) {
         e.printStackTrace();
      }
      
      DefaultMutableTreeNode root = new DefaultMutableTreeNode("전체"), node[] = new DefaultMutableTreeNode[5];
      try {
         String rt[] = "상의,하의,신발,아우터,액세서리".split(",");
         for (int i = 0; i < node.length; i++) {
            node[i] = new DefaultMutableTreeNode(rt[i]);
            rs = db.execute("select * from subcategory where c_no = " + (i + 1));
            while (rs.next()) {
               node[i].add(new DefaultMutableTreeNode(rs.getString(2)));
            }
            root.add(node[i]);
         }
      } catch (Exception e) {
         e.printStackTrace();
      }
      
      wp.add(jsp = new JScrollPane(tree = new JTree(root)));
      tree.collapseRow(0);
      tree.addTreeSelectionListener(e -> {
         TreePath ph = tree.getSelectionPath();
         if (ph != null && ph.getPathCount() == 1) {
            tree.expandRow(0);
         } else {
            category = ph.getLastPathComponent().toString();
            dUP();
         }
      });
      sz(jsp, 100, 0);
      
      cp.add(jsp = new JScrollPane(p0 = new JPanel(new BorderLayout())));
      emp(p0, 0, 10, 10, 10);
      sz(jsp, 900, 515);
      
      p0.add(p1 = new JPanel(new FlowLayout(0)), n);
      for (int i = 0; i < bn1.length; i++) {
         p1.add(jb1[i] = new JButton(bn1[i]));
         sz(jb1[i], 90, 30);
         bk(jb1[i], Color.white);
         int a = i;
         jb1[i].addActionListener(e -> {
            if (a == 0) {
            orderby = " order by p_price desc, p.p_no asc";
         } else if (a == 1) {
            orderby = " order by p_price asc, p.p_no asc";
         } else {
            orderby = " order by star desc, p.p_no asc";
         }
            dUP();
         });
      }
      
      p0.add(mp = new JPanel(new GridLayout(0, 4, 10, 10)), c);
      
      dUP();
      shp();
   }
   
   private void dUP() {
      mp.removeAll();
      try {
         int i = 0;
         String sql1 = "SELECT p.p_no, p.p_name, p_price, (p_price * (1 - sa_sale / 100)), IF(start_date <= '" + daf.format(new Date()) + "' AND end_date >= '" + daf.format(new Date()) + "', 1, 0), p_img, round(AVG(r_star),1) AS star FROM productList p LEFT " + "JOIN subcategory sb ON p.sb_no = sb.sb_no LEFT JOIN salelist s ON p.p_no = s.p_no LEFT JOIN purchase pu ON p.p_no" + " = pu.p_no LEFT JOIN review r ON pu.pu_no = r.pu_no where p_name like '%" + jt.getText() + "%'";
         
         if (!category.isEmpty()) {
             sql1 += " and sb.sb_name = '" + category + "'";
         }
         
         rs = db.execute(sql1 + " GROUP BY p.p_no " + orderby);
         
         if (!rs.next()) {
         wmsg("검색 결과가 없습니다.");
         return;
         }
         rs.beforeFirst();
         
         while (rs.next()) {
            mp.add(p0 = new JPanel(new BorderLayout()));
            int pno = rs.getInt(1);
            p0.addMouseListener(new MouseAdapter() {
               @Override
               public void mouseClicked(MouseEvent e) {
	               if (vq.uno != 0) {
		               vq.pno = pno;
		               new product_form();
		               dispose();
	               } else {
		               wmsg("로그인을 해주세요.");
		               dispose();
		               new login_form();
	               }
               }
            });
            line(p0, Color.black);
            p0.add(img = new JLabel(blob(rs.getBinaryStream(6), 150, 170)));
            emp(img, 10, 0, 0, 0);
            p0.add(p1 = new JPanel(new BorderLayout()), s);
            emp(p1, 0, 10, 0, 0);
            p1.add(jl = new JLabel(name(rs.getString(2), 15)));
            p1.add(p2 = new JPanel(new FlowLayout(0)), s);
            emp(p2, 0, 35, 0, 0);
            if (rs.getInt(5) == 1) {
               p2.add(jl = new JLabel("<html><strike>" + rs.getString(3) + "원</strike></html>"));
               p2.add(jl = new JLabel(rs.getInt(4) + "원"));
               fk(jl, Color.red);
            } else {
               p2.add(jl = new JLabel(rs.getString(3) + "원"));
               p2.add(jl = new JLabel());
            }
            i++;
         }
         for (int j = 0; j < 8 - i; j++) {
        	 mp.add(new JPanel());
         }
      } catch (Exception e) {
         e.printStackTrace();
      }
   }
}
