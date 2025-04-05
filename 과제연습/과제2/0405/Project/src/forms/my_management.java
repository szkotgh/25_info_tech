package forms;

import java.awt.GridLayout;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.JButton;

import aframe.aframe;
import jdbc.vq;

public class my_management extends aframe {
	public my_management() {
		fs("관리");
		cp.setLayout(new GridLayout(5, 1, 10, 10));
		emp(cp, 30, 50, 30, 50);
		
		jb = new JButton("      로그아웃      ");
		bl(jb);
		cp.add(jb);
		jb.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				imsg("로그아웃 되었습니다.");
				vq.uno = 0;
				dispose();
				new main_form();
			}
		});
		
		jb = new JButton("정보수정");
		bl(jb);
		cp.add(jb);
		
		jb = new JButton("구매목록");
		bl(jb);
		cp.add(jb);
		
		jb = new JButton("장바구니");
		bl(jb);
		cp.add(jb);
		
		jb = new JButton("상품등록");
		bl(jb);
		cp.add(jb);
		
		shp();
	}
}
