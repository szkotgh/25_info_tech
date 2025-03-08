import java.awt.Color;

import javax.swing.UIManager;
import javax.swing.plaf.ColorUIResource;

import form.a·Î±×ÀÎ;
import jdbc.db;

public class main {

	public static void main(String[] args) {
		try {
			for (Object f : UIManager.getLookAndFeelDefaults().keySet())
				if (f.toString().contains("background"))
					UIManager.getLookAndFeelDefaults().put(f, new ColorUIResource(Color.white));
			db.DBS();
			
			
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
