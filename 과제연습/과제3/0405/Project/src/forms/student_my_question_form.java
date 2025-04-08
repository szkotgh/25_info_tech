package forms;

import java.awt.event.WindowEvent;

import aframe.aframe;

public class student_my_question_form extends aframe {
	public student_my_question_form() {
		fs("³» Áú¹®");
		setSize(400, 400);
		sh();
	}
	
	@Override
	public void windowClosing(WindowEvent e) {
		dispose();
		new student_main_form();
	}
}
