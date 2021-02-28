using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
  public  class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductDelted = "Ürün Silindi";
        public static string ProductUpdated = "Ürün Düzenlendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public static string MaintanceTime = "";
        public static string TeslimEdilmedi = "Araba Henüz Teslim Edilmedi";
        public static string deger = "Kiralama Tarihi Teslim Tarihinden Büyük Olamaz";

        public static string ArabaResmi5Adet = "Bir arabanın en fazla 5 resmi olabilir.";



        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";


        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
    }
}
