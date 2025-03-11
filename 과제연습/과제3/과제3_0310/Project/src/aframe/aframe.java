package aframe;

import java.sql.ResultSet;
import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.Map;
import java.util.Properties;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.table.DefaultTableCellRenderer;

import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.FontMetrics;
import java.awt.Frame;
import java.awt.GridLayout;
import java.awt.HeadlessException;
import java.awt.Image;
import java.awt.PrintJob;
import java.awt.Toolkit;
import java.awt.Dialog.ModalExclusionType;
import java.awt.Dialog.ModalityType;
import java.awt.datatransfer.Clipboard;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;
import java.awt.font.TextAttribute;
import java.awt.im.InputMethodHighlight;
import java.awt.image.ColorModel;
import java.awt.image.ImageObserver;
import java.awt.image.ImageProducer;
import java.net.URL;

public class aframe extends JFrame implements WindowListener, MouseListener {
    JPanel main, n_panel, w_panel, c_panel, s_panel, e_panel;
    public static String bl_north  = BorderLayout.NORTH;
    public static String bl_east   = BorderLayout.EAST;
    public static String bl_center = BorderLayout.CENTER;
    public static String bl_west   = BorderLayout.WEST;
    public static String bl_south  = BorderLayout.SOUTH;
    public static DefaultTableCellRenderer cell = new DefaultTableCellRenderer();
    
    ResultSet db_result;
    
    public static Thread th;
    public static Toolkit default_toolkit = Toolkit.getDefaultToolkit();
    public static SimpleDateFormat default_date_format = new SimpleDateFormat("yyyy-MM-DD");
    public static DecimalFormat    default_decm_format = new DecimalFormat("#,##0");
    
    
    public void create_window(String title) {
		setTitle(title);
		setSize(800, 500);
		setDefaultCloseOperation(DISPOSE_ON_CLOSE);
		
		setIconImage(Toolkit.getDefaultToolkit().createImage("datafiles/icon/logo.png"));
		
		add(main = new JPanel(new BorderLayout()));
		main.add(n_panel = new JPanel(new BorderLayout()),bl_north);
		main.add(w_panel = new JPanel(new BorderLayout()),bl_west);
		main.add(c_panel = new JPanel(new BorderLayout()),bl_center);
		main.add(s_panel = new JPanel(new BorderLayout()),bl_south);
		main.add(e_panel = new JPanel(new BorderLayout()),bl_east);
		
		addWindowListener(this);
		addMouseListener(this);
		cell.setHorizontalAlignment(0);
		th = new Thread();
    }
    
    public void warning_message(String msg) {
    	JOptionPane.showMessageDialog(null, msg, "경고", 0);
    }
    
    public void info_message(String msg) {
    	JOptionPane.showMessageDialog(null, msg, "정보", 1);
    }
    
	@Override
	public void windowClosed(WindowEvent e) {
		System.out.println("win ended");
		info_message("정상 종료되었습니다.");
	}

	@Override
	public void mouseClicked(MouseEvent e) {
		// TODO Auto-generated method stub
		warning_message("어허 그대여, 클릭하지 마시오.");
	}


	@Override
	public void mousePressed(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}


	@Override
	public void mouseReleased(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}


	@Override
	public void mouseEntered(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}


	@Override
	public void mouseExited(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}


	@Override
	public void windowOpened(WindowEvent e) {
		// TODO Auto-generated method stub
		
	}


	@Override
	public void windowClosing(WindowEvent e) {
		// TODO Auto-generated method stub
		
	}


	@Override
	public void windowIconified(WindowEvent e) {
		// TODO Auto-generated method stub
		
	}


	@Override
	public void windowDeiconified(WindowEvent e) {
		// TODO Auto-generated method stub
		
	}


	@Override
	public void windowActivated(WindowEvent e) {
		// TODO Auto-generated method stub
		
	}


	@Override
	public void windowDeactivated(WindowEvent e) {
		// TODO Auto-generated method stub
		
	}
}
