import java.awt.Color;

import javax.swing.UIManager;
import javax.swing.plaf.ColorUIResource;

import form.login_screen;
import jdbc.db;

public class main {

	public static void main(String[] args) {
		try {
			for (Object f : UIManager.getLookAndFeelDefaults().keySet())
				if (f.toString().contains("background"))
					UIManager.getLookAndFeelDefaults().put(f, new ColorUIResource(Color.white));
			db.DBS();
			new login_screen();
			
		} catch (Exception e) {
			
		}
	}

}
