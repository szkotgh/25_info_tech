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
import javax.swing.border.EmptyBorder;

import aframe.aframe;

public class c_find extends aframe {
	JTextField jt[] = new JTextField[2];
	GridBagConstraints grid;
	
	public void form() {
		card_form.p[2].setLayout(new BorderLayout());
		bk(card_form.p[2], Color.WHITE);
		card_form.p[2].add(cp = new JPanel(new GridBagLayout()), c);
		bk(cp, Color.WHITE);
		grid = new GridBagConstraints();
		grid.fill = GridBagConstraints.BOTH;
		grid.insets = new Insets(15, 2, 2, 2);
		GridXY(jl = new JLabel("아이디 : "), 0, 0, 1, 1);
		GridXY(jl = new JLabel("생년월일 : "), 1, 0, 1, 1);
		GridXY(jt[0] = new JTextField(12), 0, 1, 1, 3);
		GridXY(jt[1] = new JTextField(12), 1, 1, 1, 3);
		
		card_form.p[2].add(sp = new JPanel(new FlowLayout()), s);
		bk(sp, Color.WHITE);
		sp.add(jb = new JButton("확인"));
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
