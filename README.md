# Hastane Otomasyonu | C# WinForms

Bu proje, **C# Windows Forms** kullanılarak geliştirilmiş, **SQL Server** destekli bir **Hastane Otomasyon Sistemi**dir.  
Hasta, Doktor ve Sekreter rolleri için ayrı paneller sunarak randevu ve kullanıcı yönetimini gerçek hayata uygun bir senaryo ile ele alır.

Küçük ve orta ölçekli sağlık kuruluşlarının temel ihtiyaçlarını karşılayacak şekilde tasarlanmıştır.

---

## 🎯 Projenin Amacı

Bu uygulama ile:

- Hastane içerisindeki farklı kullanıcı rolleri ayrıştırılır
- Randevu oluşturma ve takip süreçleri dijitalleştirilir
- Doktor, branş ve hasta yönetimi merkezi bir yapıdan sağlanır
- WinForms üzerinde gerçek bir otomasyon mantığı uygulanır

Amaç; masaüstü uygulama geliştirme, veritabanı kullanımı ve rol bazlı erişim mantığını pratikte göstermektir.

---

## 🧩 Kullanıcı Rolleri & Paneller

### 👤 Hasta Paneli
- Hasta kayıt olma
- TC Kimlik No ve şifre ile giriş
- Branş ve doktor seçerek randevu oluşturma
- Kendi randevularını görüntüleme

### 👨‍⚕️ Doktor Paneli
- Kendisine ait randevuları listeleme
- Hasta şikayetlerini görüntüleme
- Kişisel bilgilerini güncelleme

### 🧑‍💼 Sekreter Paneli
- Doktor ve branş ekleme / düzenleme
- Randevu oluşturma ve yönetme
- Hastane duyurularını ekleme ve listeleme

Bu yapı sayesinde **rol bazlı yetkilendirme mantığı** açık ve sade bir şekilde uygulanmıştır.

---

## 📅 Randevu Yönetim Sistemi

- Randevular branş ve doktora göre oluşturulur
- Aynı saat ve doktora birden fazla randevu verilmesi engellenir
- Randevular hem hasta hem doktor panelinde görüntülenebilir
- Sekreter paneli üzerinden tüm randevular merkezi olarak yönetilir

---

## 🗃️ Veritabanı & Mimari Yapı

### 📌 Veritabanı
- SQL Server kullanılmıştır
- Temel tablolar:
  - Hastalar
  - Doktorlar
  - Branşlar
  - Randevular
  - Duyurular

### 📌 Kod Yapısı
- `sqlbaglantisi.cs` ile merkezi veritabanı bağlantısı
- Her form kendi sorumluluğuna sahiptir
- CRUD işlemleri kontrollü şekilde uygulanmıştır
- WinForms projelerine uygun sade ve okunabilir yapı tercih edilmiştir

---

## 🛠️ Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|---------|---------|
| C# | Ana programlama dili |
| Windows Forms | Masaüstü kullanıcı arayüzü |
| SQL Server | Veritabanı yönetimi |
| ADO.NET | Veritabanı bağlantıları |
| Visual Studio | Geliştirme ortamı |

---

## 🚀 Kurulum & Çalıştırma

1. Repository’yi klonla:
   ```bash
   git clone https://github.com/Erenncitak/hastane-otomasyonu-winforms.git
2. Visual Studio ile `.sln` dosyasını aç
3. sqlbaglantisi.cs dosyası içerisindeki connection string'i kendi SQL Server ayarlarına göre düzenle
4. SQL Server üzerinden gerekli veritabanını ve tabloları oluştur
5. Projeyi Çalıştır
   
---

## 🔐 Demo Giriş Bilgileri

Projeyi incelemek isteyenler için örnek kullanıcı hesapları:

### 👤 Hasta Girişi
- Kullanıcı Adı: **eren**
- Şifre: **111**

### 👨‍⚕️ Doktor Girişi
- Kullanıcı Adı: **bilal**
- Şifre: **222**
  
- ### 👨‍⚕️ Sekreter Girişi
- Kullanıcı Adı: **bilal**
- Şifre: **222**

> Bu bilgiler yalnızca **demo amaçlıdır**.  
> Gerçek uygulamalarda şifreler hash’li şekilde saklanmalıdır.

---

## 🧠 Bu Proje Ne Gösteriyor?

Bu proje özellikle şunları kanıtlar:

✔ C# WinForms ile masaüstü uygulama geliştirme

✔ SQL Server ile veritabanı işlemleri

✔ Rol bazlı kullanıcı ve yetkilendirme yapısı

✔ Randevu ve iş akışı yönetimi

✔ Gerçek hayata uygun senaryo modelleme

✔ Temel OOP prensipleri

---

## 👤 Geliştirici

**Eren Çıtak**  
GitHub: https://github.com/Erenncitak  

Bu proje öğrenme ve kendimi geliştirme amacıyla hazırlanmıştır.  
Geri bildirim ve önerilere açıktır.
