using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Compression;

namespace DemoEncryptAES
{

    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadListBox();
        }

        private void btnEncriptar_Click(object sender, EventArgs e)
        {
        }

        public static byte[] generateRandomSalt()
        {
            byte[] data = new byte[16];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for(int i = 0; i < 10; i++)
                {
                    rng.GetBytes(data);
                }
            }
                return data;
        }

        private void encriptarFichero(string inputFile, string password, byte[] salt, string outputPath)
        {
            string currentPath = System.Environment.CurrentDirectory;                                               //Ruta no absoluta donde está el proyecto
            string pathCifrados = currentPath.Substring(0, currentPath.LastIndexOf("bin")) + "Cifrados" + "\\";     //Ruta donde se encuentran los cifrados
            string pathZIPs = currentPath.Substring(0, currentPath.LastIndexOf("bin")) + "FicherosZIP" + "\\";      //Ruta donde se almacenarán los zips

            //Crear el archivo -> el parametro path nos indica donde se creará el archivo cifrado .mmz
            FileStream fsCrypt = new FileStream(outputPath + "\\" + inputFile + ".mmz", FileMode.Create);

            //password string a byte arrray
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            // Rijndael algoritmo
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

            //http://stackoverflow.com/questions/2659214/why-do-i-need-to-use-the-rfc2898derivebytes-class-in-net-instead-of-directly
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            //Modos de cifrado: http://security.stackexchange.com/questions/52665/which-is-the-best-cipher-mode-and-padding-mode-for-aes-encryption
            AES.Mode = CipherMode.CBC;

            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(pathZIPs + inputFile, FileMode.Open);

            byte[] buffer = new byte[1048576];
            int read;

            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents(); 
                    cs.Write(buffer, 0, read);
                }

                // Close up
                fsIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
            }

        }

        private void desencriptarArchivo(string inputFile, string outputFile, string password, byte[] salt)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CBC;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents();
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
            }
        }

        private void crearZIP(string filename, IEnumerable<string> files)
        {
            // Create and open a new ZIP file
            var zip = ZipFile.Open(filename, ZipArchiveMode.Create);
            foreach (var file in files)
            {
                // Add the entry for each file
                zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
            }
            // Dispose of the object when we are done
            zip.Dispose();
        }

        private void btnDesencriptar_Click(object sender, EventArgs e)
        {
        }

        private void btnEncriptar_Click_1(object sender, EventArgs e)
        {
        }

        private void btnZIP_Click(object sender, EventArgs e)
        {

        }

        private void btn_AbrirPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    txtBox_Path.Text = fbd.SelectedPath;
                    if(files.Length == 0)
                    {
                        MessageBox.Show("No puedes encriptar un directorio vacío", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string path_str = txtBox_Path.Text ;
                        showListBoxFiles(path_str);
                        loadListBox();
                    }
                    
                }
            }
        }

        private void showListBoxFiles(string path)
        {
            listBox_Files.Items.Clear(); //Limpieza de los archivos
            foreach(string str in Directory.GetFiles(path))
            {
                listBox_Files.Items.Add(Path.GetFileName(str));
            }
        }

        private void btnEncriptar_Click_2(object sender, EventArgs e)
        {
            //Primero comprobamos que no se haya seleccionado un directorio vacío
            try
            {
                string[] files = Directory.GetFiles(txtBox_Path.Text);

                string fecha = returnFecha();               //Necesario para crear tanto la carpeta y el zip
                string pass = generarPasswordAleatoria();   //Contraseña a almacenar en un txt para usar después
                byte[] salte = generateRandomSalt();        //El salt para encriptar el archivo. Lo almacenaremos en un archivo

                string currentPath = System.Environment.CurrentDirectory;                                               //Ruta no absoluta donde está el proyecto
                string pathCifrados = currentPath.Substring(0, currentPath.LastIndexOf("bin")) + "Cifrados" + "\\";     //Ruta donde se encuentran los cifrados
                string dirCipher = pathCifrados + "\\carpeta" + fecha;                                                  //Ruta final de la carpeta donde se almacenarán los ficheros de cifrado (cifrado.mmz, password, salt)
                string pathZIPs = currentPath.Substring(0, currentPath.LastIndexOf("bin")) + "FicherosZIP" + "\\";      //Ruta donde se almacenarán los zips

                if (files.Length == 0) //No hay archivos
                {
                    MessageBox.Show("No puedes encriptar un directorio vacío", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(files.Length >= 1)
                {
                    zipAndCreateFolder(fecha, true);
                    /*
                     * Crear dos archivos dentro de la carpeta que hemos creado con el metodo zipAndCreateFolder():
                     *  - password.txt  -> Para posteriormente desencriptar
                     *  - salt.txt      -> Necesario para desencriptar leer su contenido
                     * */
                    File.Open(dirCipher + "\\password.txt", FileMode.Create).Close();
                    File.Open(dirCipher + "\\salt.txt", FileMode.Create).Close();

                    //Guardamos la contraseña
                    File.WriteAllText(dirCipher + "\\password.txt", pass);
                    //Guardamos el salt
                    File.WriteAllBytes(dirCipher + "\\salt.txt", salte);

                    //Comenzamos el cifrado
                    
                    string zipAEncriptar = pathZIPs + "ficheroZIP" + fecha + ".zip";
                    encriptarFichero("ficheroZIP" + fecha + ".zip", pass, salte, dirCipher);
                    loadListBox();
                    File.Delete(zipAEncriptar);
                    MessageBox.Show("Cifrado realizado con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(System.ArgumentException)
            {
                MessageBox.Show("Por favor, selecciona un directorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btn_desencriptar_Click(object sender, EventArgs e)
        {
            string currentPath = System.Environment.CurrentDirectory;
            string pathCifrados = currentPath.Substring(0, currentPath.LastIndexOf("bin")) + "Cifrados" + "\\";
            string pathDescifrados = currentPath.Substring(0, currentPath.LastIndexOf("bin")) + "Descifrados" + "\\";
            try
            {
                string currentItem = listBox_carpetaCifrados.SelectedItem.ToString();
                string fullPath = pathCifrados + currentItem;   //Ruta con la que trabajaremos para descrifrar

                string sinCarpeta = currentItem.Remove(0, 8);
                string zipString = "ficheroZIP_" + sinCarpeta + ".zip";

                string pass = File.ReadAllText(fullPath + "//password.txt");
                string cifradoMMZ = fullPath + "//" + zipString + ".mmz";   //El archivo a descifrar
                byte[] salt = File.ReadAllBytes(fullPath + "//salt.txt");

                //Crear la carpeta donde se guardará el descifrado correspondiente a la fecha de cifrado
                string carpetaAGuardarDescifrado = pathDescifrados + "descifrado_" + sinCarpeta;
                //Nombre del archivo zip descifrado
                string zipNuevo = carpetaAGuardarDescifrado + "//zipDESCIFRADO_" + sinCarpeta + ".zip";

                if (!Directory.Exists(carpetaAGuardarDescifrado))
                {
                    Directory.CreateDirectory(carpetaAGuardarDescifrado);
                }
                desencriptarArchivo(cifradoMMZ, zipNuevo, pass, salt);
                MessageBox.Show("Desencriptado OK. Se ha generado un nuevo archivo zip con los archivos descifrados. A continuación, se extraerá su contenido", "Aviso", MessageBoxButtons.OK);
                ZipFile.ExtractToDirectory(zipNuevo, carpetaAGuardarDescifrado);
                Process.Start("explorer.exe", carpetaAGuardarDescifrado);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Selecciona una carpeta para desencriptar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void zipAndCreateFolder(string nameFecha, Boolean crearZIP)
        {

            //Crear carpeta dentro de cifrados con la fecha
            string currentPath = System.Environment.CurrentDirectory;
            string pathCifrados = currentPath.Substring(0, currentPath.LastIndexOf("bin")) + "Cifrados" + "\\";
            string pathZIPs = currentPath.Substring(0, currentPath.LastIndexOf("bin")) + "FicherosZIP" + "\\";

            string dirCipher = pathCifrados + "\\carpeta" + nameFecha;
            if (!Directory.Exists(dirCipher))
            {
                Directory.CreateDirectory(dirCipher);
            }

            if (crearZIP) //Crea el archivo ZIP
            {
                ZipFile.CreateFromDirectory(txtBox_Path.Text, pathZIPs + "\\ficheroZIP" + nameFecha + ".zip");
            }

        }

        private string returnFecha()
        {
            string fechaHoy = DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss");

            fechaHoy = fechaHoy.Replace("/", "");
            fechaHoy = fechaHoy.Replace(":", "");
            fechaHoy = fechaHoy.Replace(" ", "_");                                                                                                                                                                                                                       

            return "_" + fechaHoy;
        }

        private string getFechaFromListBox(string str)
        {
            string nl = "\r\n";
            string sinCarpeta = str.Remove(0,8);
            string dia = sinCarpeta.Substring(0, 2);
            string mes = "";
            switch(sinCarpeta.Substring(2, 2).ToString())
            {
                case "01":
                    mes = "Enero";
                    break;
                case "02":
                    mes = "Febrero";
                    break;
                case "03":
                    mes = "Marzo";
                    break;
                case "04":
                    mes = "Abril";
                    break;
                case "05":
                    mes = "Mayo";
                    break;
                case "06":
                    mes = "Junio";
                    break;
                case "07":
                    mes = "Julio";
                    break;
                case "08":
                    mes = "Agosto";
                    break;
                case "09":
                    mes = "Septiembre";
                    break;
                case "10":
                    mes = "Octubre";
                    break;
                case "11":
                    mes = "Noviembre";
                    break;
                case "12":
                    mes = "Diciembre";
                    break;
                default:
                    break;
            }
            string anio = sinCarpeta.Substring(4, 4);
            string hora = sinCarpeta.Substring(9, 2);
            string minuto = sinCarpeta.Substring(11, 2);
            string segundo = sinCarpeta.Substring(13, 2);


            string msj = "Día: " + dia + nl + "Mes: " + mes + nl + "Año: " + anio + nl + "Hora: " + hora + ":" + minuto + ":" + segundo;

            return msj;
        }

        private string generarPasswordAleatoria()
        {
            Random randm = new Random();
            const int lengthPassword = 16;
            const string charsPermitidos = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
            char[] caracteres = new char[lengthPassword];

            for(int i = 0; i < lengthPassword; i++)
            {
                caracteres[i] = charsPermitidos[randm.Next(0, charsPermitidos.Length)];
            }

            return new string(caracteres);
        }

        private void loadListBox()
        {
            string currentPath = System.Environment.CurrentDirectory;
            string pathCifrados = currentPath.Substring(0, currentPath.LastIndexOf("bin")) + "Cifrados" + "\\";
            listBox_carpetaCifrados.DataSource = Directory.GetDirectories(pathCifrados).Select(Path.GetFileName).ToList();
        }

        private void listBox_carpetaCifrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox_carpetaCifrados.SelectedIndex != -1)
            {
                string strSeleccionado = listBox_carpetaCifrados.SelectedItem.ToString();
                txtBox_fechaCifrado.Text = "";
                txtBox_fechaCifrado.Text = getFechaFromListBox(strSeleccionado);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}