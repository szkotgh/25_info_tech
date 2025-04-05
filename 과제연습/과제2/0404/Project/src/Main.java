import forms.main_form;
import jdbc.db;

public class Main {
	public static void main(String[] args) {
		db.init();
		new main_form();
	}
}
