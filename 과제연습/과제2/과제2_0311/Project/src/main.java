import java.awt.Color;

import javax.swing.UIManager;
import javax.swing.plaf.ColorUIResource;

import forms.card_form;
import forms.login_form;
import forms.main_form;
import jdbc.db;

public class main {
	public static void main(String[] args) {
		try {
			for (Object f : UIManager.getLookAndFeelDefaults().keySet())
				if (f.toString().contains("background"))
					UIManager.getLookAndFeelDefaults().put(f, new ColorUIResource(Color.WHITE));
			
			db.init();
			new main_form();
//			new card_form();
		} catch(Exception e) {
			e.printStackTrace();
		}
	}
}
