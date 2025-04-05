package forms;

import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.WindowEvent;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.border.MatteBorder;

import jdbc.db;
import jdbc.vq;
import aframe.aframe;

public class login_form extends aframe {
	private static final long serialVersionUID = 1L;
	
	JTextField jt[] = new JTextField[2];
	String ln[] = {"아이디", "비밀번호"};
	
	JLabel msg;
	
	int ck = 0;
	
	public login_form() {
		fs("로그인");
		emp(pc, 20, 20, 20, 20);
		np.add(jl = new JLabel("로그인", 0));
		emp(np, 0, 0, 20, 0);
		ft(jl, 1, 20);
		
		cp.add(p0 = new JPanel (new GridLayout(0, 1, 10, 10)));
		for (int i=0; i<jt.length; i++) {
			p0.add(p1= new JPanel(new FlowLayout()));
			
			p1.add(jl = new JLabel(ln[i]));
			sz(jl, 55, 30);
			
			p1.add(jt[i] = new JTextField());
			sz(jt[i], 200, 30);
		}
		
		ep.add(jb = new JButton("로그인"));
		bl(jb);
		
		// Functions
		jb.addActionListener(e -> {
			if (e.getSource().equals(jb)) {
				String id = jt[0].getText().trim();
				String pw = jt[1].getText().trim();
				
				if (id.isEmpty() || pw.isEmpty()) {
					wmsg("빈칸이 있습니다.");
					return;
				}
				try {
					rs = db.execute("SELECT * FROM user WHERE u_id = '" + id + "' AND u_pw = '" + pw + "'");
					
					if(rs.next()) {
						vq.uno = rs.getInt(1);
						imsg(rs.getString(4) + "님 환영합니다.");
						dispose();
						new main_form();
					} else {
						wmsg("아이디 또는 비밀번호를 다시 확인해주세요.");
					}
				} catch (Exception e2) {
					e2.printStackTrace();
				}
			}
			
			
			try {
				
			} catch (Exception e2) {
				e2.printStackTrace();
			}
		});
		// end Functions
		
		sp.setLayout(new FlowLayout(0));
		sz(sp, 200, 20);
		emp(sp, 10, 45, 0, 0);
		sp.add(msg = new JLabel("빈칸이 있습니다."));
		ft(msg, 0, 13);
		fk(msg, Color.red);
		msg.setBorder(new MatteBorder(0, 0, 1, 0, Color.red));
		msg.setVisible(false);
		
		shp();
	}

	@Override
	public void windowClosing(WindowEvent e) {
		// TODO Auto-generated method stub
		new main_form();
	}
}
