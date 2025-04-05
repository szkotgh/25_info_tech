package forms;

import java.awt.Font;
import java.awt.event.WindowEvent;

import javax.swing.JLabel;

import aframe.aframe;

public class lanking_form extends aframe {
	public lanking_form() {
		fs("·©Å·");
		cp.add(jl = new JLabel("·©Å·"));
		ft(jl, Font.BOLD, 32);
		shp();
	}
	
	@Override
	public void windowClosing(WindowEvent e) {
		new login_form();
	}
}
