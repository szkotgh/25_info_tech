package forms;

import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.GridLayout;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import javax.swing.border.MatteBorder;

import aframe.aframe;
import jdbc.db;
public class login_form extends aframe {
	JTextField login_id = new JTextField();
	JPasswordField login_pw = new JPasswordField();
	String login_str[] = {"ID", "PW"};
	JLabel login_msg;
	
	private void show_msg(String text) {
		login_msg.setText(text);
		login_msg.setVisible(true);
	}
	
	private void login() {
		String input_id = login_id.getText();
		String input_pw = new String(login_pw.getPassword());
		
		if (input_id.equals("") || input_pw.equals("")) {
			show_msg("빈칸이 있습니다.");
			return;
		}
		
		try {
			// admin
			if ("admin".equals(input_id) && "1234".equals(input_pw)) {
				imsg("관리자님 환영합니다.");
				return;
			} else if ("admin".equals(input_id)) {
				show_msg("비밀번호가 일치하지 않습니다.");
				return;
			}
			
			// teacher
			rs = db.execute("select * from teacher");
			while (rs.next()) {
				if (rs.getString(3).equals(input_id) && rs.getString(4).equals(input_pw)) {
					imsg(rs.getString(2) + " 선생님 환영합니다.");
					return;
				} else if (rs.getString(3).equals(input_id)) {
					show_msg("비밀번호가 일치하지 않습니다.");
					return;
				}
			}
			
			// user
			rs = db.execute("select * from user");
			while (rs.next()) {
				if (rs.getString(3).equals(input_id) && rs.getString(4).equals(input_pw)) {
					imsg(rs.getString(2) + " 학생님 환영합니다.");
					return;
				} else if (rs.getString(3).equals(input_id)) {
					show_msg("비밀번호가 일치하지 않습니다.");
					return;
				}
			}
		} catch (Exception e) {
			e.printStackTrace();
			show_msg("데이터베이스 오류입니다.");
			return;
		}
		
		show_msg("존재하지 않는 계정입니다.");
		return;
	}
	
	public login_form() {
		fs("로그인");
		
		emp(pc, 30, 30, 30, 30);
		
		np.add(jl = new JLabel("Question", JLabel.CENTER));
		emp(jl, 0, 0, 20, 0);
		ft2(jl, 1, 30);
		
		cp.add(p0 = new JPanel(new GridLayout(0, 1, 5, 5)));
		
		p0.add(p1 = new JPanel(new FlowLayout()));
		p1.add(jl = new JLabel("ID"));
		sz(jl, 40, 30);
		p1.add(login_id = new JTextField());
		sz(login_id, 230, 30);
		login_id.addActionListener(e -> login());
		
		p0.add(p1 = new JPanel(new FlowLayout()));
		p1.add(jl = new JLabel("PW"));
		sz(jl, 40, 30);
		p1.add(login_pw = new JPasswordField());
		sz(login_pw, 230, 30);
		login_pw.addActionListener(e -> login());
		
		ep.add(jb = new JButton("로그인"));
		jb.addActionListener(e -> login());
		emp(ep, 0, 5, 0, 0);
		sz(jb, 70, 70);
		
		sp.setLayout(new FlowLayout(FlowLayout.LEFT));
		sp.add(login_msg = new JLabel("빈칸이 있습니다."));
		emp(sp, 0, 45, 0, 0);
		sz(sp, 50, 30);
		ft(login_msg, 0, 14);
		fk(login_msg, Color.RED);
		login_msg.setBorder(new MatteBorder(0, 0, 1, 0, Color.RED));
		login_msg.setVisible(false);
		
		shp();
	}
}
