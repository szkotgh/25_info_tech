package forms;

import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.border.MatteBorder;

import aframe.aframe;
import jdbc.db;
import jdbc.vq;

public class login_form extends aframe {
	JTextField login_id = new JTextField();
	JTextField login_pw = new JTextField();
	JLabel status_jl = new JLabel();
	
	private void show_status(String msg) {
		status_jl.setText(msg);
		status_jl.setVisible(true);
	}
	
	private void login() {
		String input_id = login_id.getText();
		String input_pw = login_pw.getText();
		
		if (input_id.equals("") || input_pw.equals("")) {
			show_status("빈칸이 있습니다.");
			return;
		}
		
		if ("admin".equals(input_id) && "1234".equals(input_pw)) {
			imsg("관리자님 환영합니다.");
			dispose();
			new lanking_form();
			return;
		} else if("admin".equals(input_id)) {
			show_status("비밀번호가 일치하지 않습니다.");
			return;
		}
		
		try {
			// user
			rs = db.execute("SELECT * FROM USER");
			while (rs.next()) {
				String id = rs.getString(3);
				String pw = rs.getString(4);
				String name = rs.getString(2);
				
				if (id.equals(input_id) && pw.equals(input_pw)) {
					imsg(name + " 학생님 환영합니다.");
					vq.uname = name;
					dispose();
					new student_main();
					return;
				} else if (id.equals(input_id)) {
					show_status("비밀번호가 일치하지 않습니다.");
					return;
				}
			}
			
			// teacher
			rs = db.execute("SELECT * FROM TEACHER");
			while (rs.next()) {
				String id = rs.getString(3);
				String pw = rs.getString(4);
				String name = rs.getString(2);
				
				if (id.equals(input_id) && pw.equals(input_pw)) {
					imsg(name + " 선생님 환영합니다.");
					vq.uname = name;
					dispose();
					new teacher_main();
					return;
				} else if (id.equals(input_id)) {
					show_status("비밀번호가 일치하지 않습니다.");
					return;
				}
			}
		} catch (Exception e) {
			wmsg("DB 오류입니다.");
			return;
		}
		
		show_status("존재하지 않는 회원입니다.");
		return;
	}
	
	public login_form() {
		fs("로그인");
		emp(pc, 30, 30, 30, 30);
		
		np.setLayout(new FlowLayout());
		np.add(jl = new JLabel("Question"));
		ft(jl, Font.BOLD, 30);
		emp(jl, 0, 0, 30, 0);
		
		cp.setLayout(new GridLayout(0, 1, 10, 10));
		cp.add(p0 = new JPanel(new FlowLayout()));
		p0.add(jl = new JLabel("ID"));
		sz(jl, 40, 30);
		p0.add(login_id);
		sz(login_id, 230, 30);
		
		cp.setLayout(new GridLayout(0, 1, 10, 10));
		cp.add(p0 = new JPanel(new FlowLayout()));
		p0.add(jl = new JLabel("PW"));
		sz(jl, 40, 30);
		p0.add(login_pw);
		sz(login_pw, 230, 30);
		
		ep.add(jb = new JButton("로그인"));
		jb.addActionListener(e -> login());
		bl(jb);
		
		sp.setLayout(new FlowLayout(FlowLayout.LEFT));
		sp.add(status_jl = new JLabel("빈칸이 있습니다"));
		sz(sp, 200, 30);
		emp(sp, 0, 45, 0, 0);
		status_jl.setBorder(new MatteBorder(0, 0, 1, 0, Color.RED));
		sz(status_jl, 200, 30);
		fk(status_jl, Color.red);
		
		status_jl.setVisible(false);
		shp();
	}
}