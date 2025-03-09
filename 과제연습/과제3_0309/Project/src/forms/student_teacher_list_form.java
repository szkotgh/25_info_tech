package forms;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.FlowLayout;import java.awt.GridBagLayout;
import java.awt.GridLayout;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseMotionAdapter;
import java.awt.event.WindowEvent;

import javax.swing.JComboBox;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;

import aframe.aframe;
import jdbc.db;
import jdbc.vq;

public class student_teacher_list_form extends aframe {
	String cn[] = {"��ü", "�亯����", "����Ǯ�̰� ���� ��"};
	String ln[] = {"�̸� :", "�з� : "};
	
	public student_teacher_list_form() {
		fs("������ ���");
		emp(pc, 10, 10, 50, 10);
		emp(np, 0, 0, 20, 0);
		
		np.add(jl = new JLabel(), w);
		png(jl, "icon/logo", 50, 50);
		
		np.add(jl = new JLabel("�������� �����ϼ���!",4),c);
		ft(jl, 0, 15);
		emp(jl, 0, 0, 0, 40);
		np.add(p0 = new JPanel(new FlowLayout(4)),e);
		p0.add(jc = new JComboBox<>(cn),e);
		sz(jc, 150, 30);
		jc.addActionListener(e -> {
			dup();
		});
		
		cp.add(jsp = new JScrollPane(jp = new JPanel(new GridLayout(1,0))));
		sz(jsp, 520, 160);
		line(jsp, new Color(0,0,0,0));
		jsp.setHorizontalScrollBarPolicy(31);
		jsp.addMouseMotionListener(new MouseMotionAdapter() {
			@Override
			public void mouseDragged(MouseEvent e) {
				jsp.getHorizontalScrollBar().setValue((int) (e.getX() * 2));
			}
		});
		
		dup();
		shp();
	}

	private void dup() {
		jp.removeAll();
		try {
			String sql = jc.getSelectedIndex() == 1 ? " order by per desc" : jc.getSelectedIndex() == 2 ? " order by cnt desc" : "";
			
			rs = db.rs("SELECT c.tno,t.name,t.uni,count(c.explan) as cnt,(round(count(c.explan)/count(c.tno) * 100)) as per,count(c.tno) FROM catalog c,teacher t where c.tno = t.tno group by c.tno" + sql);
			
			while (rs.next()) {
				jp.add(p0 = new JPanel(new BorderLayout()));
				line(p0, Color.black);
				sz(p0, 250, 150);
				
				p0.add(p1 = new JPanel(new BorderLayout()), n);
				p1.add(p2 = new JPanel(new BorderLayout()), w);
				p2.add(img = new JLabel());
				jpg(img, "teacher/" + rs.getInt(1), 75, 75);
				line(img, Color.black);
				emp(p2, 10, 10, 10, 15);
				int tno = rs.getInt(1);
				String tea = rs.getString(2);
				img.addMouseListener(new MouseAdapter() {
					@Override
					public void mouseClicked(MouseEvent e) {
						if (e.getClickCount() == 2) {
							vq.tno = tno;
							vq.teacher = tea;
							if (vq.move == 1) {
								dispose();
								new student_question_regi_form();
							} else {
								try {
									db.stmt.execute("update catalog set tno = " + vq.tno + "where cno =" + vq.cno);
									dispose();
									new student_my_question_form();
								} catch (Exception e2) {
									e2.printStackTrace();
								}
							}
						}
					}
				});
				
				p1.add(p2 = new JPanel(new GridLayout(0, 1, 5, 10)), c);
				p2.add(jl = new JLabel("�̸� : " + rs.getString(2), 0));
				ft(jl, 0, 13);
				p2.add(jl = new JLabel("�з� : " + rs.getString(3), 0));
				ft(jl, 0, 13);
				emp(p2, 20, 0, 20, 0);
				
				p0.add(p1 = new JPanel(new BorderLayout()), s);
				p1.add(jl = new JLabel("",0),w);
				png(jl, "icon/pencil", 40, 40);
				emp(jl, 0, 10, 15, 0);
				
				p1.add(p2 = new JPanel( new GridLayout(0,1,5,10)), c);
				p2.add(jl = new JLabel("�� ����Ǯ���� ���� : " + rs.getString(4) + "��"));
				ft(jl, 0, 11);
				p2.add(jl = new JLabel("�亯�� : " + rs.getString(5) + "%"));
				ft(jl, 0, 11);
				fk(jl, Color.red);
				emp(p2, 10, 15,10, 0);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	@Override
	public void windowClosing(WindowEvent e) {
		if (vq.move == 1) {
			new student_question_regi_form();
		} else {
			new student_my_question_form();
		}
	}
}
