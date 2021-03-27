using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {

        // CAR
        public static string CarAdded = "Araba Eklendi.";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba Güncellendi";
        public static string CarsListed = "Arabalar Listelendi.";
        public static string CarNameInvalid = "Arabanın Günlük Fiyatı 0 Girilemez";

        // BRAND
        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandsListed = "Markalar Listelendi.";
        public static string BrnadDeleted = "Marka Silindi.";
        public static string BrandUpdated = "Marka Güncellendi.";
        public static string BrandNameInvalid = "Marka İsmi 2 Karakterden Uzun Olmalı";

        // COLOR 
        public static string ColorAdded = "Renk Eklendi.";
        public static string ColorsListed = "Renkler Listelendi.";
        public static string ColorDeleted = "Renk Silindi.";
        public static string ColorUpdated = "Renk Güncellendi.";


        // CUSTOMER
        public static string CustomerAdded = "Müşteri Eklendi.";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerDeleted = "Müşteri Silindi.";
        public static string CustomersListed = "Müşteriler Listelendi";


        // USER
        public static string UserAdded = "Kullanıcı Eklendi.";
        public static string UsersListed = "Kullanıcılar Listelendi.";
        public static string UserDeleted = "Kullanıcı Silindi.";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserPassword = "Kullanıcı Şifresi En Az 8 Krakter Olmalı";
        public static string UserFristName = "Kullanıcı Adı Girilmelidir";
        public static string UserLastName = "Kullanıcı Soyadı Girlmelidir";
        public static string UserEmail = "Kullanıcı Email Gecersizdir";
        public static string AuthorizationDenied = "Yetkiniz Yok";



        // RENTAL
        public static string RentalAdded = "Araba Kiralama Bilgisi Eklendi.";
        public static string RentalUpdated = "Araba Kiralama Bilgisi Güncellendi";
        public static string RentalDeleted = "Araba Kiralama Bilgisi Silindi";
        public static string RentalsListed = "Araba kiralama Bilgiler Listelendi";
        public static string RentalsRentDate = "Araba Kiralama Tarihi Girilmelidir";
        public static string CarNotReturned = "Araba Teslim Edilmedi";
 
        //CarImage
        public static string CarImageAdded = "Araba Resmi Eklendi.";
        public static string CarImageUpdated = "Araba Resmi Güncellendi";
        public static string CarImageDeleted = "Araba Resmi Silindi";
        public static string CarImageListed = "Araba Resmi Listelendi";
        public static string CarImageAddingLimit = "Araba sisteminde en fazla 5 resim eklenebilir";
        public static string IncorrectFileExtension = " Araba  resmi dosya uzantısı  yanlıştır";
        public static string PictureNotFound = "Silinecek veya güncellenecek resim bulunamadı";
        public static string[] ValidImageFileTypes = {".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO"};

        //Auth
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";


        // SYSTEM
        public static string MaintenanceTime = "Sistem Bakımda";
    }
}
