using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
                Console.WriteLine("Login Completed");
                Selection();
            }

            Console.ReadKey();
        }

        public static bool Login(NhanVien[] nhanVien)
        {
            Console.WriteLine("\t\t\t**********Login**********");
            int num = 0;
            do
            {
                Console.Write("Nhap vao username: ");
                string sUser = Console.ReadLine();
                Console.Write("Nhap vao password: ");
                string sPass = Console.ReadLine();
               
                foreach (NhanVien i in nhanVien)
                {
                    if (String.Compare(sUser, i.sUser) == 0 && String.Compare(sPass, i.sPass) == 0)
                    {             
                        //Menu();
                        return true;
                    }
                }
                if (num == 0)
                {
                   
                    Console.WriteLine("Login failed");
                    num++;
                }
              
            } while (num == 0);
            return false;
        }
       
        public static void Selection()
        {
           Sach[] sach = new Sach[0];
           DocSach(ref sach);
            int selection;
            do
            {
                Console.WriteLine("_____Please make a selection_____");
                Console.WriteLine("1/ Quan ly sach");
                Console.WriteLine("2/ Quan ly phieu muon");
                Console.Write("Your selection: ");
                int.TryParse(Console.ReadLine(), out selection);
                Console.Clear();
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("_____Please make a selection_____");
                        Console.WriteLine("1/ Hien thi tat ca sach");
                        Console.WriteLine("2/ Them sach");
                        Console.WriteLine("3/ Xoa sach");
                        Console.Write("Your selection: ");
                        int.TryParse(Console.ReadLine(), out selection);
                        Console.Clear();
                        switch(selection)
                        {
                            case 1:                           
                                XuatSach(sach);
                                break;
                            case 2:
                                GhiSach(ref sach);
                                break;
                            case 3:
                                Console.Write("Nhap vao ma sach can xoa: ");
                                string sMa = Console.ReadLine();
                                XoaSach(ref sach, sMa);
                                XuatSach(sach);
                                //ghi sach chua dc
                                //GhiSach(ref sach);
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
            Console.WriteLine("\t\t\t----------Xuat Sach----------");
            for (int i = 0; i < arrA.Length; i++)
            {
                Console.WriteLine("Sach thu {0}", i + 1);
                Console.WriteLine("Ma nhan vien: {0}", arrA[i].sMaSach);
                Console.WriteLine("Ho ten nhan vien: {0}", arrA[i].sTenSach);
                Console.WriteLine("Ho ten nhan vien: {0}", arrA[i].sTacGia);
                Console.WriteLine("Ho ten nhan vien: {0}", arrA[i].sNhaXB);
                Console.WriteLine("Ho ten nhan vien: {0}", arrA[i].iGiaBan);
                Console.WriteLine("Ho ten nhan vien: {0}", arrA[i].iNamPhatHanh);
                Console.WriteLine("Ho ten nhan vien: {0}", arrA[i].iSoTrang);
                Console.WriteLine("Ho ten nhan vien: {0}", arrA[i].dtNgayNhapKho);
                Console.WriteLine("Ho ten nhan vien: {0}", arrA[i].iTinhTrang);
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
        static void GhiSach(ref Sach[] arrA)
        {
            string[] names = new string[] { "Tran Van A"};
            using (StreamWriter sw = new StreamWriter("Sach.txt"))
            {

                foreach (string s in names)
                {
                    sw.WriteLine(s);
                }
            }
        }
        //doc phieu muon
        static void DocPhieuMuon(ref PhieuMuon[] arrA)
        {
            int iN = 0;
            using (StreamReader sR = new StreamReader("PhieuMuon.txt"))
            {
                int.TryParse(sR.ReadLine(), out iN);
                arrA = new PhieuMuon[iN];
                for (int i = 0; i < iN; i++)
                {
                    string sLine = sR.ReadLine();
                    string[] separator = new string[] { "#" };
                    string[] arrCon = sLine.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    int.TryParse(arrCon[0], out arrA[i].iSoPhieuMuon);
                    arrA[i].sMaBanDoc = arrCon[1];
                    arrA[i].sMaSach = arrCon[2];
                    DateTime.TryParse(arrCon[3], out arrA[i].dtNgayMuon);
                    DateTime.TryParse(arrCon[4], out arrA[i].dtNgayTra);
                    int.TryParse(arrCon[5], out arrA[i].iTinhTrang);
                }
            }
        }
        //xuat phieu muon
        static void XuatPhieuMuon(PhieuMuon[] arrA)
        {
            Console.WriteLine("\t\t\t----------Xuat Sach----------");
            for (int i = 0; i < arrA.Length; i++)
            {
                Console.WriteLine("********************************");
                Console.WriteLine("Phieu muon thu {0}", i + 1);
                Console.WriteLine("So phieu muon : {0}", arrA[i].iSoPhieuMuon);
                Console.WriteLine("Ma ban doc: {0}", arrA[i].sMaBanDoc);
                Console.WriteLine("Ma sach : {0}", arrA[i].sMaSach);
                Console.WriteLine("Ngay muon : {0}", arrA[i].dtNgayMuon);
                Console.WriteLine("Ngay tra: {0}", arrA[i].dtNgayTra);
                Console.WriteLine("Tinh trang phieu muon : {0}", arrA[i].iTinhTrang);
            }
            Console.WriteLine("\t\t\t---------------------------------");
        }
        static void MuonSach(PhieuMuon[] arrA)
        {
            Console.Write("Nhap vao ma sach can muon : ");
            string sMaSachMuon = Console.ReadLine();
            Console.Write("Nhap vao ma ban doc : ");
            string sMaBanDocMuon = Console.ReadLine();
            PhieuMuon[] phieuMuons = new PhieuMuon[0];
            DocPhieuMuon(ref phieuMuons);
            
            
        }
    }
}
