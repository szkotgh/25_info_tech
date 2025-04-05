package forms;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Component;
import java.awt.FlowLayout;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

import aframe.aframe;

public class a_login extends aframe {
	JTextField jt[] = new JTextField[2];
	GridBagConstraints grid;
	
	public void form() {
		card_form.p[0].setLayout(new BorderLayout());
		bk(card_form.p[0], Color.WHITE);
		card_form.p[0].add(cp = new JPanel(new GridBagLayout()), c);
		grid = new GridBagConstraints();
		grid.fill = GridBagConstraints.BOTH;
		grid.insets = new Insets(15, 2, 2, 2);
		GridXY(jl = new JLabel("아이디 : "), 0, 0, 1, 1);
		GridXY(jl = new JLabel("비밀번호 : "), 1, 0, 1, 1);
		GridXY(jt[0] = new JTextField(12), 0, 1, 1, 3);
		GridXY(jt[1] = new JTextField(12), 1, 1, 1, 3);
		
		card_form.p[0].add(sp = new JPanel(new FlowLayout()), s);
		sp.add(jb = new JButton("로그인"));
		emp(sp, 0, 0, 7, 0);
	}
	
	private void GridXY(Component c, int i, int j, int k, int l) {
		grid.gridx = j;
		grid.gridy = i;
		grid.gridwidth = l;
		grid.gridheight = k;
		cp.add(c, grid);
	}
}
