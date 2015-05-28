namespace SqlToCsv
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using CsvHelper;

    /// <summary>
    ///     The sql to csv.
    /// </summary>
    public partial class SQLToCSV : Form
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SQLToCSV" /> class.
        /// </summary>
        public SQLToCSV()
        {
            this.InitializeComponent();

            this.logBox.DrawMode = DrawMode.OwnerDrawVariable;
            this.logBox.MeasureItem += this.lst_MeasureItem;
            this.logBox.DrawItem += this.lst_DrawItem;
        }

        /// <summary>
        /// Sets the filename that will be targeted by this program
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void setCsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
                                        {
                                            Filter = "CSV Files|*.csv", 
                                            AddExtension = true, 
                                            FileName = this.csvFileName.Text, 
                                            CheckPathExists = true, 
                                            DefaultExt = ".csv", 
                                            AutoUpgradeEnabled = true, 
                                            CreatePrompt = true, 
                                            SupportMultiDottedExtensions = true, 
                                            Title = "Choose location for created CSV"
                                        };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.csvFileName.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// The run query_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void runQuery_Click(object sender, EventArgs e)
        {
            var sqlConnectionString = this.sqlConnectionStringBox.Text;
            var fileName = this.csvFileName.Text;
            var query = this.sqlQueryBox.Text;

            this.Log("Starting...");

            if (!this.IsValidSetup(sqlConnectionString, fileName, query))
            {
                return;
            }

            this.RunQueryAndSave(sqlConnectionString, query, fileName);

            this.Log("Finished");
        }

        /// <summary>
        /// The is valid setup.
        /// </summary>
        /// <param name="sqlConnectionString">
        /// The sql connection string.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="System.Boolean"/> .
        /// </returns>
        private bool IsValidSetup(string sqlConnectionString, string fileName, string query)
        {
            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                this.Log("No connection string provided");
                return false;
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                this.Log("No CSV file name provided");
                return false;
            }

            if (string.IsNullOrWhiteSpace(query))
            {
                this.Log("No SQL query provided");
                return false;
            }

            return true;
        }

        /// <summary>
        /// The run <paramref name="query"/> and save.
        /// </summary>
        /// <param name="sqlConnectionString">
        /// The sql connection string.
        /// </param>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        private void RunQueryAndSave(string sqlConnectionString, string query, string fileName)
        {
            var dataTable = this.RunQuery(sqlConnectionString, query);
            if (dataTable == null)
            {
                this.Log("Query did not run successfully");
                return;
            }

            var success = this.SaveResultsToFile(dataTable, fileName);
            this.Log(success ? string.Format("Results written to {0}", fileName) : "Failed to write results to file");
        }

        /// <summary>
        /// The save results to file.
        /// </summary>
        /// <param name="dataTable">
        /// The data table.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// The <see cref="System.Boolean"/> .
        /// </returns>
        private bool SaveResultsToFile(DataTable dataTable, string fileName)
        {
            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Create))
                {
                    using (TextWriter textWriter = new StreamWriter(stream))
                    {
                        using (var csv = new CsvWriter(textWriter))
                        {
                            CreateHeaders(dataTable, csv);
                            CreateRecords(dataTable, csv);
                            return true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.Log(exception.ToString());
                return false;
            }
        }

        /// <summary>
        /// The create records.
        /// </summary>
        /// <param name="dataTable">
        /// The data table.
        /// </param>
        /// <param name="csv">
        /// The csv.
        /// </param>
        private static void CreateRecords(DataTable dataTable, CsvWriter csv)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                row.ItemArray.Select(field => field.ToString()).ToList().ForEach(csv.WriteField);
                csv.NextRecord();
            }
        }

        /// <summary>
        /// The create headers.
        /// </summary>
        /// <param name="dataTable">
        /// The data table.
        /// </param>
        /// <param name="csv">
        /// The csv.
        /// </param>
        private static void CreateHeaders(DataTable dataTable, CsvWriter csv)
        {
            dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToList().ForEach(csv.WriteField);
            csv.NextRecord();
        }

        /// <summary>
        /// The create connection.
        /// </summary>
        /// <param name="connectionString">
        /// </param>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="System.Object"/> .
        /// </returns>
        private DataTable RunQuery(string connectionString, string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable results = new DataTable();
                            dataAdapter.Fill(results);
                            return results;
                        }
                    }
                }
            }

                // ReSharper disable once CatchAllClause
            catch (Exception exception)
            {
                this.Log(exception.ToString());
                return null;
            }
        }

        /// <summary>
        /// The log.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        private void Log(string message)
        {
            var item = string.Format("{0} : {1}", DateTime.Now.ToString("HH:mm:ss"), message);
            this.logBox.Items.Insert(0, item);
        }

        /// <summary>
        /// The lst_ measure item.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight =
                (int)
                e.Graphics.MeasureString(this.logBox.Items[e.Index].ToString(), this.logBox.Font, this.logBox.Width)
                    .Height;
        }

        /// <summary>
        /// The lst_ draw item.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index == -1)
            {
                return;
            }

            e.Graphics.DrawString(this.logBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }
    }
}