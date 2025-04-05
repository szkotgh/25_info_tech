package forms;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

import aframe.aframe;
import jdbc.db;
import jdbc.vq;

import java.sql.*;
import java.text.*;
import java.util.Date;

public class product_form extends aframe {
   JLabel nl[] = new JLabel[5]; // 제품명, 평점, 판매자, 카테고리, 상품금액 라벨
   JLabel star[] = new JLabel[5]; // 별점
   JLabel size[] = new JLabel[4]; // 사이즈
   String si[] = "S,M,L,XL".split(","); // 사이즈 텍스트
   JLabel down[] = new JLabel[4]; // 감소
   JLabel count[] = new JLabel[4]; // 개수
   JLabel up[] = new JLabel[4]; // 증가   
   JLabel amount; // 총 금액   
   JButton jb[] = new JButton[2];
   String bn[] = "구매,장바구니".split(",");   
   int sizecount[] = new int[4]; // 사이즈 최대 개수
   int price; // 상품 금액   
   int sub, pno[]; // 서브카테고리, 상품번호

   public product_form() {
      fs("상품");
      emp(pc, 10, 10, 10, 10);      
      emp(wp, 10, 0, 0, 0);
      wp.add(img = new JLabel());
      sz(img, 250, 290);
      line(img, Color.black);

      emp(cp, 15, 10, 0, 50);
      cp.add(p0 = new JPanel(new GridLayout(0, 1, 0, 5)), BorderLayout.NORTH);
      for (int i=0; i<nl.length; i++) {
         if (i == 1) {
            p0.add(p1 = new JPanel(new FlowLayout(0, 0, 0)));
            p1.add(nl[i] = new JLabel("평점 : "));
            for (int j=0; j<star.length; j++) {
               p1.add(star[j] = new JLabel());
               jpg(star[j], "별점이미지/2", 20, 20);
               emp(star[j], 0, 5, 0, 0);
            }
            p1.addMouseListener(new MouseAdapter() {
               @Override
               public void mouseClicked(MouseEvent e) {
//                  new j리뷰();
                  dispose();
               }
            });
         } else {
            p0.add(nl[i] = new JLabel());
         }
         ft(nl[i], 1, 14);
      }
      emp(p0, 0, 0, 10, 0);

      cp.add(p0 = new JPanel(new BorderLayout()), BorderLayout.CENTER);
      p0.add(p1 = new JPanel(new GridLayout(1, 0, 7, 0)), BorderLayout.NORTH);
      for (int i = 0; i < size.length; i++) {
         p1.add(size[i] = new JLabel(si[i], SwingConstants.CENTER));
         sz(size[i], 60, 50);
         line(size[i], Color.black);
         size[i].setOpaque(true);
         int a = i;
         size[i].addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
               if (size[a].getBackground() == Color.blue) {
                  bk(size[a], Color.white);
                  fk(size[a], Color.black);
                  fk(up[a], Color.lightGray);
                  fk(down[a], Color.lightGray);
                  fk(count[a], Color.lightGray);
                  count[a].setText("0");
                  am();
               } else {
                  fk(size[a], Color.white);
                  bk(size[a], Color.blue);
                  fk(up[a], Color.black);
                  fk(down[a], Color.black);
                  fk(count[a], Color.black);
               }
            }
         });
      }
      emp(p1, 0, 0, 10, 0);

      p0.add(amount = new JLabel("총 금액 : 0"), BorderLayout.SOUTH);
      ft(amount, 1, 14);
      emp(amount, 0, 0, 10, 0);

      cp.add(p0 = new JPanel(new FlowLayout(FlowLayout.CENTER, 20, 0)), BorderLayout.SOUTH);
      for (int i = 0; i < bn.length; i++) {
         p0.add(jb[i] = new JButton(bn[i]));
         sz(jb[i], 100, 30);
         bl(jb[i]);
         int a = i;
         jb[i].addActionListener(e -> {
            if (a == 0) { // 구매
               int ct = 0;
               for (int j = 0; j < count.length; j++) {
                  ct += rei(count[j].getText());
               }
               if (ct == 0) {
                  wmsg("사이즈를 선택해 주세요.");
                  return;
               }
               try {
                  db.stmt.execute("insert into shoppingbasket values(0,'" + vq.pno 
                     + "','" + vq.uno + "','" + rei(count[0].getText()) + "','" 
                     + rei(count[1].getText()) + "','" + rei(count[2].getText()) + "','" 
                     + rei(count[3].getText()) + "')");
                  vq.move = 2;
//                  new h결제();
                  dispose();
               } catch (Exception e2) {
                  e2.printStackTrace();
               }
            } else { // 장바구니
               if (vq.uno == 0) {
                  wmsg("로그인을 해주세요.");
                  return;
               } else {
                  vq.card = 3;
//                  mypage = new dcard();
                  dispose();
               }
            }
         });
      }
   }

   private void am() { // 총 금액 계산
      int ct = 0;
      for (int i = 0; i < count.length; i++) {
         ct += rei(count[i].getText());
      }
      amount.setText("총 금액 : " + new DecimalFormat("#,###").format(ct * price));
   }

   private void dUP() {
      mp.removeAll();
      try {
         ResultSet rs = db.execute("SELECT p.p_name, round(AVG(r_star),1), u_name, c_name, "
            + "sb_name, IF(start_date <= '" + new SimpleDateFormat("yyyy-MM-dd").format(new Date()) 
            + "' AND end_date >= '" + new SimpleDateFormat("yyyy-MM-dd").format(new Date()) 
            + "', (p_price * (1 - sa_sale / 100)), p_price), p.p_s, p.p_m, p.p_l, p.p_xl, p_img, p.sb_no "
            + "FROM productList p LEFT JOIN subcategory sb ON p.sb_no = sb.sb_no "
            + "LEFT JOIN salelist s ON p.p_no = s.p_no LEFT JOIN purchase pu ON p.p_no = pu.p_no "
            + "LEFT JOIN review r ON pu.pu_no = r.pu_no, user u, category c "
            + "WHERE c.c_no = sb.c_no AND u.u_no = p.u_no AND p.p_no = " + vq.pno);
         
         if (rs.next()) {
            price = rs.getInt(6);
            nl[0].setText("제품명 : " + rs.getString(1));
            nl[2].setText("판매자 : " + rs.getString(3));
            nl[3].setText("카테고리 : " + rs.getString(4) + "/" + rs.getString(5));
            nl[4].setText("상품금액 : " + new DecimalFormat("#,###").format(price));
         }
      } catch (Exception e) {
         e.printStackTrace();
      }
   }

   @Override
   public void windowClosing(WindowEvent e) {
      new main_form();
   }
}
