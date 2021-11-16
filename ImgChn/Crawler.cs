using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;

namespace ImgChn
{
    class Crawler
    {
        LinkedList<string> download_information;
        int tipo;
        string folder;
        public Task task1;
        public Task task2;
        public Task task3;
        public Task task4;
        public Task task5;
        public Task task6;
        
        public Crawler(int t, string f)
        {
            download_information = new LinkedList<string>();
            tipo = t;
            folder = f + "\\";
        }


        public void getAllData(string url, int option)
        {
            try
            {
                using (WebClient web1 = new WebClient())
                {
                    string data = web1.DownloadString(url);
                    string trimmed_url = url;
                    trimmed_url = trimmed_url.Substring(0, trimmed_url.IndexOf(".com") + 4);
                    getItems(data, option, trimmed_url);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("El link no pudo ser accesado correctamente, por favor intente de nuevo");
            }

        }

        //Se encarga de subdividr el link en todas las fotos disponibles
        public void getItems(String data, int option, string url)
        {
            String CopyData = data;
            LinkedList<String> pieces = new LinkedList<String>();
            String textToSearch = "album__main";
            String anchor = "<div";

            while (CopyData.Contains(textToSearch))
            {
                int album_index = CopyData.IndexOf(textToSearch);
                CopyData = CopyData.Substring(album_index);
                int anchor_index = CopyData.IndexOf(anchor);
                String piece = CopyData.Substring(0, anchor_index);
                pieces.AddLast(piece);
                CopyData = CopyData.Substring(anchor_index);
            }
            trimPieces(pieces, option, url);
        }

        //Busca los links y los nombres de cada foto disponible
        public void trimPieces(LinkedList<String> pieces, int option, string url)
        {
            LinkedList<Item> items = new LinkedList<Item>();
            foreach (String info in pieces)
            {
                int name_index = info.IndexOf("title=");
                int link_index = info.IndexOf("href");
                String copy = info;
                string[] strings = Regex.Split(copy, "\n");

                string name = strings[1];
                int pos = name.IndexOf("title=");
                name = name.Substring(pos + 6);
                name = Regex.Replace(name, @"[^A-Za-z0-9 .-]", string.Empty);

                string link = strings[2];
                pos = link.IndexOf("href");
                link = link.Substring(pos + 6).Trim();
                link = url + link.Substring(0, link.Length - 1);

                Item item = new Item(link, name);
                items.AddLast(item);
            }
            //single thread
            //accesser(items, option);
            //multi thread
            divider(items, option);
        }

        //Genera opcion multi threading
        public void divider(LinkedList<Item> items, int option)
        {
            LinkedList<Item> items1 = new LinkedList<Item>();
            LinkedList<Item> items2 = new LinkedList<Item>();
            LinkedList<Item> items3 = new LinkedList<Item>();
            LinkedList<Item> items4 = new LinkedList<Item>();
            LinkedList<Item> items5 = new LinkedList<Item>();
            LinkedList<Item> items6 = new LinkedList<Item>();
            for (int i = 0; i < 20; i++)
            {
                items1.AddLast(items.First());
                items.RemoveFirst();
            }
            for (int i = 0; i < 20; i++)
            {
                items2.AddLast(items.First());
                items.RemoveFirst();
            }
            for (int i = 0; i < 20; i++)
            {
                items3.AddLast(items.First());
                items.RemoveFirst();
            }
            for (int i = 0; i < 20; i++)
            {
                items4.AddLast(items.First());
                items.RemoveFirst();
            }
            for (int i = 0; i < 20; i++)
            {
                items5.AddLast(items.First());
                items.RemoveFirst();
            }
            for (int i = 0; i < 20; i++)
            {
                items6.AddLast(items.First());
                items.RemoveFirst();
            }
            task1 = Task.Factory.StartNew(() => accesser(items1, option));
            task2 = Task.Factory.StartNew(() => accesser(items2, option));
            task3 = Task.Factory.StartNew(() => accesser(items3, option));
            task4 = Task.Factory.StartNew(() => accesser(items4, option));
            task5 = Task.Factory.StartNew(() => accesser(items5, option));
            task6 = Task.Factory.StartNew(() => accesser(items6, option));
        }

        //obtine la informacion de cada sub-album
        public void accesser(LinkedList<Item> items, int option)
        {
            foreach (Item item in items)
            {
                try
                {
                    using (WebClient web1 = new WebClient())
                    {
                        string data = web1.DownloadString(item.Link);
                        getFileLink(option, data, item.Info);
                        
                    }
                }
                catch (Exception e)
                {
                    //MessageBox.Show("El link no pudo ser accesado correctamente, por favor intente de nuevo");
                }

            }
        }

        //obtiene los links de cada archivo que se quiera descargar
        public void getFileLink(int option, string data, string text)
        {
            string Link = string.Empty;
            string name = string.Empty;
            bool existe = true;
            if (option == 1)
            {
                //descargar videos
                string copy = data;
                int index = copy.IndexOf("data-origin-src");
                copy = copy.Substring(index + 18);
                int index2 = copy.IndexOf("data-type");
                int index3 = copy.IndexOf("data-album-id");
                while (!copy.Substring(index2, index3).Contains("data-type=\"video\"") && index >= 0)
                {
                    index = copy.IndexOf("data-origin-src");
                    copy = copy.Substring(index + 18);
                    index2 = copy.IndexOf("data-type");
                    index3 = copy.IndexOf("data-album-id");
                }

                if (index < 0)
                {
                    //no hay videos en el link
                    existe = false;
                    name = text;
                }
                else
                {
                    int path_index = copy.IndexOf("data-path");
                    int class_index = copy.IndexOf("class=\"");
                    copy = copy.Substring(path_index + 11, class_index).Trim();
                    path_index = copy.IndexOf("\n");
                    copy = copy.Substring(0, path_index);
                    copy = copy.Substring(0, copy.Length - 1);
                    Link = copy;
                    string[] info = copy.Split(new string[] { "/" }, StringSplitOptions.None);
                    name = info[info.Length - 1];
                    string data_type = "mp4";
                    int image_index = name.IndexOf(data_type);
                    if (image_index < 0)
                    {
                        data_type = "MP4";
                        image_index = name.IndexOf(data_type);
                    }
                    if (image_index < 0)
                    {
                        //formato invalid
                    }
                    else
                    {
                        name = text + " " + name.Substring(0, name.IndexOf(data_type) + data_type.Length);
                        Link = "https://uvd.yupoo.com/1080p" + Link.Substring(0, Link.IndexOf(data_type) + data_type.Length);
                        Link = Link.ToLower();
                    }
                }
            }
            else if (option == 2)
            {
                //descargar fotos
                if (tipo == 1)
                {
                    string copy = data;
                    int index = copy.IndexOf("data-origin-src");
                    copy = copy.Substring(index + 18);
                    int index2 = copy.IndexOf("data-type");
                    int index3 = copy.IndexOf("data-album-id");
                    while (!copy.Substring(index2, index3).Contains("photo"))
                    {
                        index = copy.IndexOf("data-origin-src");
                        copy = copy.Substring(index + 18);
                        index2 = copy.IndexOf("data-type");
                        index3 = copy.IndexOf("data-album-id");
                    }

                    copy = copy.Substring(0, index2).Trim();
                    copy = copy.Substring(0, copy.Length - 1);
                    Link = copy;
                    string[] info = copy.Split(new string[] { "/" }, StringSplitOptions.None);
                    name = info[info.Length - 1];
                    string data_type = "jpg";
                    int image_index = name.IndexOf(data_type);
                    if (image_index < 0)
                    {
                        data_type = "jpeg";
                        image_index = name.IndexOf(data_type);
                    }
                    if (image_index < 0)
                    {
                        data_type = "png";
                        image_index = name.IndexOf(data_type);
                    }
                    if (image_index < 0)
                    {
                        //formato invalid
                    }
                    else
                    {
                        name = text + " " + name.Substring(0, name.IndexOf(data_type) + data_type.Length);
                        Link = "https:/" + Link.Substring(0, Link.IndexOf(data_type) + data_type.Length);
                    }

                }
                else
                {
                    //descargar ultima imagen

                    string copy = data;
                    int index = copy.IndexOf("data-origin-src");
                    copy = copy.Substring(index + 18);
                    int index2 = copy.IndexOf("data-type");
                    int index3 = copy.IndexOf("data-album-id");
                    while (index > 0)
                    {
                        index = copy.IndexOf("data-origin-src");
                        copy = copy.Substring(index + 18);
                        index2 = copy.IndexOf("data-type");
                        index3 = copy.IndexOf("data-album-id");
                    }
                    if (!copy.Substring(index2, index3).Contains("photo"))
                    {
                        //no hay imagen en el utlimo archivo
                    }
                    else
                    {
                        copy = copy.Substring(0, index2).Trim();
                        copy = copy.Substring(0, copy.Length - 1);
                        Link = copy;
                        string[] info = copy.Split(new string[] { "/" }, StringSplitOptions.None);
                        name = info[info.Length - 1];
                        string data_type = "jpg";
                        int image_index = name.IndexOf(data_type);
                        if (image_index < 0)
                        {
                            data_type = "jpeg";
                            image_index = name.IndexOf(data_type);
                        }
                        if (image_index < 0)
                        {
                            data_type = "png";
                            image_index = name.IndexOf(data_type);
                        }
                        if (image_index < 0)
                        {
                            //formato invalid
                        }
                        else
                        {
                            name = text + " " + name.Substring(0, name.IndexOf(data_type) + data_type.Length);
                            Link = "https://photo.yupoo.com/" + Link.Substring(0, Link.IndexOf(data_type) + data_type.Length);
                        }
                    }
                }
            }
            else 
            {
                // do nothing
            }
            name = name.Replace("  ", " ");
            downloadFile(Link, name, existe);
        }

        //descarga el archivo deseado
        public void downloadFile(String link, string name, bool existe = true)
        {
            string status = string.Empty;
            if (existe)
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        client.Headers.Add("Referer", "http://photo.yupoo.com");
                        client.DownloadFile(link, folder + name);
                        status = "Exito en: " + name;
                    }

                }
                catch (Exception e)
                {
                    //Do nothing
                    status = "Error en: " + name;
                }
            }
            else 
            {
                status = "No se encontro video en: " + name;
            }
            this.download_information.AddLast(status);
        }

        public void logFile()
        {
            string fileName = folder + "    00 - LogFile.txt";
            if (!File.Exists(fileName))
            {
                // Create the file and use streamWriter to write text to it.
                //If the file existence is not check, this will overwrite said file.
                //Use the using block so the file can close and vairable disposed correctly
                using (StreamWriter writer = File.CreateText(fileName))
                {
                    foreach (string line in download_information)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }



    }
}
