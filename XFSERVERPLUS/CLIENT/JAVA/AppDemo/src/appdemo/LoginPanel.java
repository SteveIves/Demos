/*
 * LoginPanel.java
 *
 * Created on June 30, 2005, 12:35 PM
 */

package appdemo;

/**
 *
 * @author  stevei
 */
public class LoginPanel extends javax.swing.JPanel {
    
    /** Creates new form LoginPanel */
    public LoginPanel() {
        initComponents();
    }
    
    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    // <editor-fold defaultstate="collapsed" desc=" Generated Code ">//GEN-BEGIN:initComponents
    private void initComponents() {
        jLabel1 = new javax.swing.JLabel();
        jTextField1 = new javax.swing.JTextField();
        jLabel2 = new javax.swing.JLabel();
        jTextField2 = new javax.swing.JTextField();
        jButton1 = new javax.swing.JButton();
        jButton2 = new javax.swing.JButton();

        setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

        jLabel1.setText("Username");
        add(jLabel1, new org.netbeans.lib.awtextra.AbsoluteConstraints(20, 20, -1, -1));

        add(jTextField1, new org.netbeans.lib.awtextra.AbsoluteConstraints(80, 20, 180, -1));

        jLabel2.setText("Password");
        add(jLabel2, new org.netbeans.lib.awtextra.AbsoluteConstraints(20, 60, -1, -1));

        add(jTextField2, new org.netbeans.lib.awtextra.AbsoluteConstraints(80, 60, 180, -1));

        jButton1.setText("OK");
        add(jButton1, new org.netbeans.lib.awtextra.AbsoluteConstraints(117, 100, 70, -1));

        jButton2.setText("Cancel");
        add(jButton2, new org.netbeans.lib.awtextra.AbsoluteConstraints(200, 100, -1, -1));

    }
    // </editor-fold>//GEN-END:initComponents
    
    
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButton1;
    private javax.swing.JButton jButton2;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JTextField jTextField1;
    private javax.swing.JTextField jTextField2;
    // End of variables declaration//GEN-END:variables
    
}
