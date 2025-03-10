package forms;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import javax.swing.JTextField;
import java.io.File;
import java.util.Date;
import java.awt.*;

import javax.imageio.ImageIO;
import javax.swing.*;
import javax.swing.border.*;
import javax.swing.filechooser.FileNameExtensionFilter;

import aframe.aframe;
import jdbc.db;
import jdbc.vq;

public class student_question_regi_form extends aframe {
    JFileChooser choo = new JFileChooser(System.getProperty("user.dir") + "/datafiles/question/");
    BufferedImage buf;
    String type = "";  
    JLabel tc;

    public student_question_regi_form() {
        fs("질문 등록");
        emp(pc, 10, 15, 15, 15);
        np.add(jl = new JLabel("질문 등록", 0));
        ft(jl, 1, 20);
        emp(np, 0, 0, 15, 0);

        wp.add(img = new JLabel());
        sz(img, 350, 250);
        line(img, Color.black);
        img.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                FileNameExtensionFilter f = new FileNameExtensionFilter("JPG Images", "jpg");
                choo.setFileFilter(f);
                choo.showOpenDialog(null);
                try {
                    buf = ImageIO.read(new File(choo.getSelectedFile().getPath()));
                    img.setIcon(new ImageIcon(new ImageIcon(buf).getImage().getScaledInstance(350, 250, 4)));
                    vq.type = choo.getSelectedFile().getName().replace(".jpg", "");
                    vq.buf = buf;
                } catch (Exception e2) {
                    e2.printStackTrace();
                }
            }
        });

        cp.add(p0 = new JPanel(new BorderLayout()));
        emp(cp, 0, 15, 0, 0);
        jt = hint("제목");
        p0.add(jt, n);
        sz(jt, 300, 30);
        line(jt, Color.black);

        jte = ahint("질문내용");
        p0.add(jte, c);
        sz(jte, 300, 200);
        Border bf = BorderFactory.createCompoundBorder(new EmptyBorder(10, 0, 10, 0), new LineBorder(Color.black, 1));
        jte.setBorder(bf);
        jte.setLineWrap(true);

        p0.add(p1 = new JPanel(new BorderLayout()), s);

        p1.add(tc = new JLabel("선생님을 선택해주세요.", 0), w);
        ft(tc, 0, 12);
        sz(tc, 150, 30);
        tc.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                vq.tt = jt.getText();
                vq.exp = jte.getText();
                dispose();
                new student_teacher_list_form();
                vq.move = 1;
            }
        });
        line(tc, Color.black);

        if (vq.buf != null) {
            buf = vq.buf;
            img.setIcon(new ImageIcon(new ImageIcon(vq.buf).getImage().getScaledInstance(350, 250, 4)));
        }

        p1.add(jb = new JButton("질문 등록"), "East");
        ft(jb, 0, 13);
        bl(jb);
        sz(jb, 120, 30);
        
        jt.addKeyListener(new KeyAdapter() {
            @Override
            public void keyPressed(KeyEvent e) {
                if (jt.getText().length() > 30) {
                    jt.setText(jt.getText().substring(0, 30));
                }
            }
        });

        jte.addKeyListener(new KeyAdapter() {
            @Override
            public void keyPressed(KeyEvent e) {
                if (jte.getText().length() > 500) {
                    jte.setText(jte.getText().substring(0, 500));
                }
            }
        });

        jb.addActionListener(e -> {
            try {
                if (vq.teacher == null) {
                    int a = JOptionPane.showConfirmDialog(null, "선생님을 선택하지 않았습니다. 선생님 폼으로 이동하시겠습니까?", "질문", JOptionPane.YES_NO_OPTION);
                    if (a == JOptionPane.YES_OPTION) {
                        vq.move = 1;
                        vq.tt = jt.getText();
                        vq.exp = jte.getText();
                        dispose();
                        new student_teacher_list_form();
                    } 
                    return;
                }

                if (jt.getText().equals("") || jte.getText().equals("")) {
                    wmsg("내용을 입력해 주세요.");
                    return;
                }

                if (buf == null) {
                    wmsg("사진을 선택해주세요.");
                    return;
                }

                String[] X = {"씨발", "시발", "썅", "병신", "새끼", "또라이", "개새끼", "존나", "테스트욕설"};
                for (String x : X) {
                    if (jt.getText().contains(x) || jte.getText().contains(x)) {
                        wmsg("비속어는 사용하실 수 없습니다.");
                        return;
                    }
                }

                db.stmt.execute("INSERT INTO catalog VALUES ('0', '" + vq.uno + "', '" + vq.tno + "', '" + vq.type + "', '" + jt.getText() + "', '" + daf.format(new Date()) + "', '" + jte.getText() + "', NULL)");

                imsg("질문이 등록되었습니다.");
                vq.buf = null;
                vq.teacher = "";
                vq.tt = "";
                vq.exp = "";
                dispose();
                new student_main_form();
            } catch (Exception e2) {
                e2.printStackTrace();
            }
        });

        if (!vq.teacher.equals("")) {
            tc.setText(vq.teacher + " 선생님");
        }
        jt.setText(vq.tt);
        jte.setText(vq.exp);

        shp();
    }

	@Override
    public void windowClosing(WindowEvent e) {
        vq.tt = "";
        vq.exp = "";
        vq.teacher = "";
        vq.buf = null;
        new student_main_form();
    }
}
