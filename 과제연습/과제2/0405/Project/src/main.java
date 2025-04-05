import forms.main_form;
import jdbc.db;

public class main {
	public static void main(String[] args) {
		db.init();
		new main_form();
	}
}
