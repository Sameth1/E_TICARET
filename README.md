# E-Ticaret Yönetim Sistemi (N-Tier Architecture)

Bu çalışma, kurumsal yazılım geliştirme prensiplerine uygun olarak, modüler ve sürdürülebilir bir e-ticaret altyapısının ASP.NET Core MVC framework'ü ile kurgulanmasını hedeflemektedir. Projenin temel odağı, iş mantığının (Business Logic) sunum katmanından tamamen ayrıştırılması ve veri erişim süreçlerinin merkezi bir yapıda yönetilmesidir.

---

## Teknik Mimari ve Tasarım Yaklaşımı

Sistem, genişletilebilirliği artırmak ve teknik borcu (technical debt) minimize etmek amacıyla katmanlı mimari (N-Tier Architecture) yapısında inşa edilmiştir:

- **Core Katmanı:** Sistemin iskeletini oluşturan varlıklar (Entities), veri transfer nesneleri (DTOs) ve arayüz (Interface) tanımlarını içerir.

- **Business Logic Layer (BLL):** Sepet yönetimi, sipariş oluşturma, favori listesi ve ürün servisleri gibi kritik iş süreçlerinin kurumsal kurallara göre işlendiği katmandır.

- **Data Access Layer (DAL):** Entity Framework Core kullanılarak veritabanı işlemlerinin soyutlandığı, repository deseni ile yönetildiği katmandır.

- **UI_MVC:** Kullanıcı etkileşiminin yönetildiği, responsive tasarım prensiplerine sahip sunum katmanıdır (ASP.NET Core MVC, Razor view engine).

---

## Temel Fonksiyonlar

- Kullanıcı yetkilendirme ve oturum yönetimi (ASP.NET Core Identity).
- Kategori ve marka bazlı dinamik ürün listeleme.
- Session tabanlı sepet ve favori listesi yönetimi.
- Checkout akışı, kart bilgisi formu ve sipariş kaydı.
- Giriş yapan kullanıcılar için sipariş geçmişi ve sipariş detayı.
- Otomatik veri tohumlama (Seed Data) ile ürün başlık, açıklama ve görsel URL’lerinin güncellenmesi.

---

## Teknoloji Yığını

| Bileşen | Teknoloji |
|--------|-----------|
| Framework | .NET 8.0 |
| ORM | Entity Framework Core (Code-First) |
| Veritabanı | MS SQL Server |
| Sunum | ASP.NET Core MVC, Razor views, Bootstrap |

---

## Kurulum ve Çalıştırma

Sistemi yerel ortamda ayağa kaldırmak için aşağıdaki adımları takip edebilirsiniz:

1. Projeyi yerel dizine klonlayın:

```bash
git clone https://github.com/Sameth1/E_TICARET.git
cd E_TICARET
```

2. SQL Server üzerinde `shop_samet` adında bir veritabanı oluşturun. `UI_MVC/appsettings.json` dosyasındaki Connection String bilgisini yerel SQL Server ayarlarınıza göre güncelleyin.

3. Terminalde DAL dizinine giderek veritabanı migrasyonlarını uygulayın:

```bash
cd DAL
dotnet ef database update --startup-project ../UI_MVC
cd ..
```

4. Uygulamayı çalıştırın:

```bash
cd UI_MVC
dotnet run
```

Tarayıcıdan konsolda belirtilen adresi (ör. `https://localhost:5001`) açarak sisteme erişebilirsiniz.

---

Canlı ortama deploy için [DEPLOY.md](DEPLOY.md) dosyasındaki adımlar kullanılabilir.
