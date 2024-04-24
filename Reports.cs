using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using MySql.Data.MySqlClient;


namespace LibraryIS
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

            // call public class connection and create a new instance of it called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();

            // connect the data grid view to the database but do not include the column names and skip the first row of the table
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM book_inventory", con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM late_fees", con);
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            dataGridView2.DataSource = table1;

            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM transactions_list;", con);
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView3.DataSource = table2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the file path for the Book Inventory Template
            string templateFilePath = "C:\\Users\\Daniela Cantillo\\Documents\\Book Inventory Template.xlsx";

            try
            {
                // Load the template Excel file
                using (XLWorkbook templateWorkbook = new XLWorkbook(templateFilePath))
                {
                    // Get the worksheet named "Book Inventory"
                    IXLWorksheet ws = templateWorkbook.Worksheet("Sheet1");

                    // Specify the starting row and column in the Excel worksheet
                    int startRow = 12; // Example: Start inserting data from row 2
                    int startColumn = 1; // Example: Start inserting data from column 1 (A)

                    // Copy data from dataGridView1 to the worksheet
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            // Explicitly convert the cell value to string
                            string cellValue = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                            // Assign the converted value to the cell in the worksheet
                            ws.Cell(i + startRow, j + startColumn).Value = cellValue;
                        }
                    }

                    // Get today's date
                    string todayDate = DateTime.Now.ToString("yyyy-MM-dd");


                    // Find the cell where you want to insert the date (for example, cell A1)
                    IXLCell dateCell = ws.Cell("F7");

                    // Set the value of the cell to the current date
                    dateCell.Value = DateTime.Today;

                    // Construct the file name with today's date
                    string fileName = $"{todayDate}_Book_Inventory.xlsx";

                    // Combine the file name with the directory path
                    string outputPath = Path.Combine(Path.GetDirectoryName(templateFilePath), fileName);

                    // Save the workbook with the updated data
                    templateWorkbook.SaveAs(outputPath);


                    // Show the output path in a message box
                    MessageBox.Show($"Data exported successfully! File saved at: {outputPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Specify the file path for the Book Inventory Template
            string templateFilePath = "C:\\Users\\Daniela Cantillo\\Documents\\Overdue Books Template.xlsx";

            try
            {
                // Load the template Excel file
                using (XLWorkbook templateWorkbook = new XLWorkbook(templateFilePath))
                {
                    // Get the worksheet named "Book Inventory"
                    IXLWorksheet ws = templateWorkbook.Worksheet("Sheet1");

                    // Specify the starting row and column in the Excel worksheet
                    int startRow = 12; // Example: Start inserting data from row 2
                    int startColumn = 1; // Example: Start inserting data from column 1 (A)

                    // Copy data from dataGridView2 to the worksheet
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView2.Columns.Count; j++)
                        {
                            // Explicitly convert the cell value to string
                            string cellValue = Convert.ToString(dataGridView2.Rows[i].Cells[j].Value);

                            // If the current column is the 5th column (index 4), treat the value as a number
                            if (j == 4)
                            {
                                double numericValue;
                                // Try to parse the cell value as a number
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    // Assign the parsed number to the cell
                                    ws.Cell(i + startRow, j + startColumn).SetValue(numericValue);
                                }
                                else
                                {
                                    // If parsing fails, just assign the cell value as string
                                    ws.Cell(i + startRow, j + startColumn).Value = cellValue;
                                }
                            }
                            else
                            {
                                // For other columns, assign the cell value as string
                                ws.Cell(i + startRow, j + startColumn).Value = cellValue;
                            }
                        }
                    }

                        // Get today's date
                        string todayDate = DateTime.Now.ToString("yyyy-MM-dd");


                    // Find the cell where you want to insert the date (for example, cell A1)
                    IXLCell dateCell = ws.Cell("E7");

                    // Set the value of the cell to the current date
                    dateCell.Value = DateTime.Today;

                    // Construct the file name with today's date
                    string fileName = $"{todayDate}_Overdue_Books.xlsx";

                    // Combine the file name with the directory path
                    string outputPath = Path.Combine(Path.GetDirectoryName(templateFilePath), fileName);

                    // Save the workbook with the updated data
                    templateWorkbook.SaveAs(outputPath);


                    // Show the output path in a message box
                    MessageBox.Show($"Data exported successfully! File saved at: {outputPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Specify the file path for the Book Inventory Template
            string templateFilePath = "C:\\Users\\Daniela Cantillo\\Documents\\Transactions List Template.xlsx";

            try
            {
                // Load the template Excel file
                using (XLWorkbook templateWorkbook = new XLWorkbook(templateFilePath))
                {
                    // Get the worksheet named "Book Inventory"
                    IXLWorksheet ws = templateWorkbook.Worksheet("Sheet1");

                    // Specify the starting row and column in the Excel worksheet
                    int startRow = 14; // Example: Start inserting data from row 2
                    int startColumn = 1; // Example: Start inserting data from column 1 (A)

                    // Copy data from dataGridView2 to the worksheet
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView3.Columns.Count; j++)
                        {
                            // Explicitly convert the cell value to string
                            string cellValue = Convert.ToString(dataGridView3.Rows[i].Cells[j].Value);

                            // If the current column is the 5th column (index 4), treat the value as a number
                            if (j == 6)
                            {
                                double numericValue;
                                // Try to parse the cell value as a number
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    // Assign the parsed number to the cell
                                    ws.Cell(i + startRow, j + startColumn).SetValue(numericValue);
                                }
                                else
                                {
                                    // If parsing fails, just assign the cell value as string
                                    ws.Cell(i + startRow, j + startColumn).Value = cellValue;
                                }
                            }
                            else
                            {
                                // For other columns, assign the cell value as string
                                ws.Cell(i + startRow, j + startColumn).Value = cellValue;
                            }
                        }
                    }

                    // Get today's date
                    string todayDate = DateTime.Now.ToString("yyyy-MM-dd");


                    // Get the date value from cell 14D and copy it to cell 7C
                    var date14D = ws.Cell("D14").GetString();
                    ws.Cell("C7").Value = date14D;

                    // Get the date value from cell 27D and copy it to cell 8C
                    var date27D = ws.Cell("D27").GetString();
                    ws.Cell("C8").Value = date27D;


                    // Find the cell where you want to insert the date (for example, cell A1)
                    IXLCell dateCell = ws.Cell("G7");

                    // Set the value of the cell to the current date
                    dateCell.Value = DateTime.Today;

                    // Construct the file name with today's date
                    string fileName = $"{todayDate}_Transactions.xlsx";

                    // Combine the file name with the directory path
                    string outputPath = Path.Combine(Path.GetDirectoryName(templateFilePath), fileName);

                    // Save the workbook with the updated data
                    templateWorkbook.SaveAs(outputPath);


                    // Show the output path in a message box
                    MessageBox.Show($"Data exported successfully! File saved at: {outputPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
