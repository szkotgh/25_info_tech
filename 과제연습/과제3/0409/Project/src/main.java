import java.sql.ResultSet;

import forms.login_form;
import jdbc.db;

public class main {
	public static void main(String[] args) {
		db.init();
		new login_form();
	}
}
