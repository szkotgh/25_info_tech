import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTable;
import javax.swing.JTextField;
import javax.swing.event.TableModelEvent;
import javax.swing.event.TableModelListener;
import javax.swing.JScrollPane;
import javax.swing.table.DefaultTableModel;

public class main {
	public static JTextField jf;
	public static boolean isClicked = false;
	
	public static JComboBox jcb;
	
    public static void main(String[] args) {
        JFrame frame = new JFrame();
        frame.setTitle("Test Table");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        
        JPanel jp = new JPanel(new FlowLayout());
        frame.add(jp);
        
//        DefaultTableModel dtm = new DefaultTableModel();
//        dtm.addColumn("GOB");
//        dtm.addColumn("RESULT");
//        for (int i=1; i<=100; i++) {
//        	dtm.addRow(new Object[]{""+i, ""+(i*i)*i});
//        }
//        
//        JTable table = new JTable(dtm);
//        
//        table.setPreferredScrollableViewportSize(new Dimension(500, 200));
//        table.setFillsViewportHeight(true);
//        
//        JScrollPane scrollPane = new JScrollPane(table);
//        
//        jp.add(scrollPane);
        frame.pack();
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }
}
