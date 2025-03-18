import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;

public class ProductTableExample {
    public static void main(String[] args) {
        SwingUtilities.invokeLater(ProductTableExample::createAndShowGUI);
    }

    private static void createAndShowGUI() {
        JFrame frame = new JFrame("상품 목록");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(800, 600);
        frame.setLayout(new BorderLayout());
        
        String[] columnNames = {"이미지", "상품명", "가격", "등록일"};
        Object[][] data = {
            {new ImageIcon("jacket.jpg"), "자켓", "675,000원", "2024-05-19"},
            {new ImageIcon("shoes.jpg"), "10008 BK HORSE LOAFER9", "350,000원", "2024-01-28"},
            {new ImageIcon("hat.jpg"), "SHOMER B88", "480,000원", "2024-01-21"}
        };
        
        DefaultTableModel model = new DefaultTableModel(data, columnNames) {
            @Override
            public Class<?> getColumnClass(int column) {
                return (column == 0) ? ImageIcon.class : String.class;
            }
        };
        
        JTable table = new JTable(model);
        table.setRowHeight(60);
        JScrollPane scrollPane = new JScrollPane(table);
        
        JPanel searchPanel = new JPanel();
        JTextField searchField = new JTextField(20);
        JButton searchButton = new JButton("검색");
        
        searchPanel.add(new JLabel("상품명:"));
        searchPanel.add(searchField);
        searchPanel.add(searchButton);
        
        frame.add(searchPanel, BorderLayout.NORTH);
        frame.add(scrollPane, BorderLayout.CENTER);
        
        frame.setVisible(true);
    }
}
