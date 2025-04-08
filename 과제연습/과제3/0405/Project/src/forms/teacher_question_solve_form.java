package forms;

import java.awt.event.WindowEvent;

import aframe.aframe;

public class teacher_question_solve_form extends aframe {
	public teacher_question_solve_form() {
		fs("문제 풀어주기");
		setSize(400, 400);
		sh();
	}
	
	@Override
	public void windowClosing(WindowEvent e) {
		dispose();
		new student_main_form();
	}
}
