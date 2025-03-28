package forms;

import java.awt.CardLayout;
import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;

import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.border.Border;

import aframe.aframe;

public class card_form extends aframe {
	
	static JPanel[] p = new JPanel[3];
	JButton jb[] = new JButton[4];
	String bn[] = {"로그인", "회원가입", "비번찾기", "종료"};
	CardLayout card = new CardLayout();
	Border bottmBorder = BorderFactory.createMatteBorder(0, 0, 1, 0, Color.BLACK);
	
	public card_form() {
		setTitle("CardLayout");
		setDefaultCloseOperation(DISPOSE_ON_CLOSE);
		setLocationRelativeTo(null);
		setSize(400, 250);
		add(np = new JPanel(new FlowLayout(FlowLayout.CENTER, 15, 10)), n);
		for (int i=0; i<jb.length; i++) {
			np.add(jb[i] = new JButton(bn[i]));
			jb[i].addActionListener(this); 
		}
		fk(jb[0], Color.RED);
		
		add(cp = new JPanel(), c);
		cp.setLayout(card);
		for (int i = 0; i < 3; i++) { 
			cp.add(p[i] = new JPanel(), String.valueOf(i));
		}
		
		new a_login().form();
		new b_join().form();
		new c_find().form();
		
		bk(np, Color.WHITE);
		np.setBorder(bottmBorder);
		setVisible(true);
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		for (int i = 0; i < 3; i++) {
			if (e.getSource() == jb[i]) {
				card.show(cp, String.valueOf(i));
				upColors(i);
				return;
			}
		}
	}

	private void upColors(int ac) {
		for (int i = 0; i < 3; i++) {
			if (i == ac) {
				fk(jb[i], Color.RED);
			} else {
				fk(jb[i], Color.BLACK);
			}
		}
	}
}
