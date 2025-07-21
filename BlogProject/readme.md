# ASP.NET Core MVC Blog Uygulaması

Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş katmanlı mimariye sahip bir blog uygulamasıdır. Temel yazı listeleme, detay görüntüleme ve veri yönetimi işlemleri gerçekleştirilir.

---

## 🚀 Kullanılan Teknolojiler

- **ASP.NET Core MVC** – Modern web uygulamaları geliştirmek için kullanılan güçlü web framework'ü.  
- **Entity Framework Core (In-Memory)** – Hafif ORM çözümü, test ve örnek veri senaryoları için bellek içi veritabanı.  
- **Tag Helpers** – Razor sayfalarında özel HTML yardımcıları geliştirme imkânı.  
- **Bootstrap 5** – Hızlı ve modern arayüz tasarımı için kullanılan CSS framework'ü.  
- **Font Awesome** – Zengin ikon setiyle UI'yi zenginleştirme.

---

## 🎯 Özellikler

- **Katmanlı Mimari**  
  - Presentation, Business, DataAccess, Entity katmanları ile temiz mimari uygulanmıştır.

- **Repository Pattern**  
  - Veri erişim katmanında soyutlama sağlanır, test edilebilirlik artar.

- **Service Layer**  
  - İş mantığı servis katmanında toplanarak controller’lar sade tutulmuştur.

- **Custom Tag Helpers**  
  - Blog yazılarının `Status` ve `ViewCount` gibi özellikleri özel HTML tag helper'lar ile görselleştirilmiştir.

- **Model Validation**  
  - Kullanıcı girdileri `Data Annotations` ile kontrol edilir.

- **Responsive Design**  
  - Bootstrap sayesinde mobil uyumlu ve esnek bir kullanıcı arayüzü sunulmuştur.

---
