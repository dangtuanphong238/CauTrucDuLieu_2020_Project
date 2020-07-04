using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

namespace QuanLyThuVien_Project2020
{
    struct Sach
    {
        public string sMaSach; // duy nhất
        public string sTenSach;
        public string sTacGia;
        public string sNhaXB;
        public int iGiaBan;
        public int iNamPhatHanh;
        public int iSoTrang;
        public DateTime dtNgayNhapKho;
        public int iTinhTrang;
    }
    struct BanDoc
    {
        public string sMaBanDoc;
        public string sHoTen;
        public DateTime dtNgayDangKy;
    }
    struct PhieuMuon
    {
        public int iSoPhieuMuon;
        public string sMaBanDoc;
        public string sMaSach;
        public DateTime dtNgayMuon; //đề yêu cầu lấy ngày hiện tại của hệ thống
        public DateTime dtNgayTra; //đề yêu cầu ngày trả = ngày mượn + 7;
        public int iTinhTrang; // mượn thì = 1; trả thì = 0;
    }
    struct NhanVien
    {
        public string sUser;
        public string sPass;
    }


    class Program
    {

        static void Main(string[] args)
        {

            NhanVien[] nhanVien = new NhanVien[0];   
            DocNhanVien(ref nhanVien);
            if(Login(nhanVien) == true)
            {
                Console.Clear();
                Console.WriteLine("\t\t_-_-_Login Completed_-_-_");
                Selection();
            }

            Console.ReadKey();
        }

        public static bool Login(NhanVien[] nhanVien)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t************************************");
            Console.Write("\t\t\t*");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\t\tLogin");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t   *");
            Console.WriteLine("\t\t\t************************************");
            int num = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t\tNhap vao username: ");
                Console.ResetColor();
                string sUser = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t\tNhap vao password: ");
                Console.ResetColor();


                string sPass = Console.ReadLine();
               
               
                





                foreach (NhanVien i in nhanVien)
                {
                    if (String.Compare(sUser, i.sUser) == 0 && String.Compare(sPass, i.sPass) == 0)
                    {
                        //num++;
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Login lan {0}", num + 2);
                    }
                }
                num++;
                if(num == 3)
                {
<<<<<<< HEAD
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t!!! Login failed !!! \n");
                    Console.ResetColor();
=======
                    Environment.Exit(0);
>>>>>>> TuanPhong
                }
            } while (num < 3);
            return false;
        }
       
        public static void Selection()
        {
           Sach[] sach = new Sach[0];
           DocSach(ref sach);
            int selection;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t***********************************");
                Console.Write("\t\t\t*");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("_____Please make a selection_____");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t***********************************");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("\t\t1/ Quan ly sach");
                Console.WriteLine("\t\t2/ Quan ly phieu muon"); 
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("\t\t\tYour selection: ");
                Console.ResetColor();
                int.TryParse(Console.ReadLine(), out selection);
                Console.Clear();
                switch (selection)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t\t***********************************");
                        Console.Write("\t\t\t*");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("_____Please make a selection_____");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("*");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t\t***********************************");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\t\t1/ Hien thi tat ca sach");
                        Console.WriteLine("\t\t2/ Them sach");
                        Console.WriteLine("\t\t3/ Xoa sach");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\t\t\tYour selection: ");
                        Console.ResetColor();
                        int.TryParse(Console.ReadLine(), out selection);
                        Console.Clear();
                        switch(selection)
                        {
                            case 1:                           
                                XuatSach(sach);
                                break;
                            case 2:
                                ThemSach();
                                break;
                            case 3:
                                Console.Write("Nhap vao ma sach can xoa: ");
                                string sMa = Console.ReadLine();
                                XoaSach(ref sach, sMa);
                                XuatSach(sach);
                                //ghi sach chua dc
                                //ThemSach();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            } while (selection >= 1 && selection <= 2);
        }
        static void XoaSach(ref Sach[] arrA, string sMaSach)
        {
            int num = 0;
            for(int i = 0; i < arrA.Length; i++)
            {
                if(String.Compare(arrA[i].sMaSach, sMaSach) == 0)
                {
                    for (int j = i; j < arrA.Length - 1; j++)
                    {
                        arrA[j] = arrA[j + 1];
                    }
                    Array.Resize(ref arrA, arrA.Length - 1);
                }
            }
            if(num == 0)
            {
                Console.WriteLine("Khong tim thay ma sach phu hop");
            }
        }
        static void XuatNhanVien(NhanVien[] arrA)
        {
            Console.WriteLine("\t\t\t----------Xuat mang----------");
            for (int i = 0; i < arrA.Length; i++)
            {
                Console.WriteLine("Nhan vien thu {0}", i + 1);
                Console.WriteLine("Ma nhan vien: {0}", arrA[i].sUser);
                Console.WriteLine("Ho ten nhan vien: {0}", arrA[i].sPass);
            }
            Console.WriteLine("\t\t\t---------------------------------");
        }
        static void DocNhanVien(ref NhanVien[] arrA)
        {
            int iN = 0;
            using (StreamReader sR = new StreamReader("Admin.txt"))
            {
                int.TryParse(sR.ReadLine(), out iN);
                arrA = new NhanVien[iN];
                for (int i = 0; i < iN; i++)
                {
                    string sLine = sR.ReadLine();
                    string[] separator = new string[] { "#" };
                    string[] arrCon = sLine.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    arrA[i].sUser = arrCon[0];
                    arrA[i].sPass = arrCon[1];
                }
            }
        }    
        static void XuatSach(Sach[] arrA)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t*****************************************");
            Console.Write("\t\t\t*");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t   ___-___Xuat Sach___-___");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t*");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t*****************************************");
            Console.ResetColor();
            Console.WriteLine("\t\t\t--------------------");
            for (int i = 0; i < arrA.Length; i++)
            {
                Console.WriteLine("Sach thu {0}", i + 1);
                Console.WriteLine("Ma sach: {0}", arrA[i].sMaSach);
                Console.WriteLine("Ten sach: {0}", arrA[i].sTenSach);
                Console.WriteLine("Tac gia: {0}", arrA[i].sTacGia);
                Console.WriteLine("Nha xuat ban: {0}", arrA[i].sNhaXB);
                Console.WriteLine("Gia: {0}", arrA[i].iGiaBan);
                Console.WriteLine("Nam phat hanh: {0}", arrA[i].iNamPhatHanh);
                Console.WriteLine("So trang: {0}", arrA[i].iSoTrang);
                Console.WriteLine("Ngay nhap kho: {0}", arrA[i].dtNgayNhapKho);
                Console.WriteLine("Tinh trang: {0}", arrA[i].iTinhTrang);
                Console.WriteLine();
            }
            Console.WriteLine("\t\t\t---------------------------------");
        }
        static void DocSach(ref Sach[] arrA)
        {
            int iN = 0;
            using (StreamReader sR = new StreamReader("Sach.txt"))
            {
                int.TryParse(sR.ReadLine(), out iN);
                arrA = new Sach[iN];
                for (int i = 0; i < iN; i++)
                {
                    string sLine = sR.ReadLine();
                    string[] separator = new string[] { "#" };
                    string[] arrCon = sLine.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    arrA[i].sMaSach = arrCon[0];
                    arrA[i].sTenSach = arrCon[1];
                    arrA[i].sTacGia = arrCon[2];
                    arrA[i].sNhaXB = arrCon[3];
                    int.TryParse(arrCon[4], out arrA[i].iGiaBan);
                    int.TryParse(arrCon[5], out arrA[i].iNamPhatHanh);
                    int.TryParse(arrCon[6], out arrA[i].iSoTrang);
                    DateTime.TryParse(arrCon[7], out arrA[i].dtNgayNhapKho);
                    int.TryParse(arrCon[8], out arrA[i].iTinhTrang);

                }
            }
        }
        static void ThemSach()
        {
            FileStream stream = new FileStream("C:\\Users\\PC\\Desktop\\CauTrucDuLieu_2020_Project\\QuanLyThuVien_Project2020\\Sach.txt", FileMode.Append);
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                Console.Write("Nhap vao ma sach: ");
                string sMa = Console.ReadLine();
                Console.Write("Nhap vao ten sach: ");
                string sTen = Console.ReadLine();
                Console.Write("Nhap vao ten tac gia: ");
                string sTenTG = Console.ReadLine();
                Console.Write("Nhap vao nha xuat ban: ");
                string sNhaXB = Console.ReadLine();
                Console.Write("Nhap vao gia ban: ");
                int iGiaBan = int.Parse(Console.ReadLine());
                int iNamPhatHanh = 0;
                do
                {
                    Console.Write("Nhap vao nam phat hanh: ");
                    iNamPhatHanh = int.Parse(Console.ReadLine());
                } while (iNamPhatHanh > DateTime.Now.Year);

                Console.Write("Nhap vao so trang: ");
                int iTrang = int.Parse(Console.ReadLine());

                int iTinhTrang = 0;
                do
                {
                    Console.Write("Nhap vao tinh trang: ");
                    iTinhTrang = int.Parse(Console.ReadLine());

                } while (iTinhTrang > 1 && iTinhTrang < 0);

                writer.WriteLine("{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#{8}", sMa, sTen, sTenTG, sNhaXB, iGiaBan, iNamPhatHanh, iTrang, DateTime.Today, iTinhTrang);
            }
        }
        static void UpdateFile()
        {
            
        }
    }
}
