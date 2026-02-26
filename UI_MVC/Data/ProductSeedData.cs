namespace UI_MVC.Data
{
    /// <summary>
    /// Gerçekçi Türkçe ürün başlıkları ve açıklamaları.
    /// Görseller: Picsum (https://picsum.photos) - ücretsiz, gerçek fotoğraflar.
    /// </summary>
    public static class ProductSeedData
    {
        private static readonly (string Title, string Description, int PicsumId)[] Items =
        {
            ("Erkek Pamuklu Basic Tişört", "Yüksek kalite %100 pamuklu kumaş. Günlük kullanım için ideal, nefes alan yapı. Yıkandığında çekmez, rengi solmaz. S, M, L, XL beden seçenekleri.", 1),
            ("Kadın Slim Fit Kot Pantolon", "Stretch denim kumaş, rahat oturuş. Günlük ve yarı resmi kullanım için uygundur. Çok yönlü gardırop parçası.", 2),
            ("Spor Ayakkabı - Unisex", "Hafif taban, nefes alan üst. Koşu ve günlük kullanım için. Kaymaz taban, uzun ömürlü kullanım.", 3),
            ("Deri Sırt Çantası", "Gerçek deri, laptop bölmeli. 15.6 inç dizüstü bilgisayar sığar. Çok bölmeli, şık ve dayanıklı.", 4),
            ("Bluetooth Kablosuz Kulaklık", "Aktif gürültü önleme, 30 saat pil ömrü. Katlanabilir tasarım, yumuşak kulak yastıkları.", 5),
            ("Akıllı Saat - Fitness Takip", "Kalp atışı, adım sayacı, uyku analizi. Suya dayanıklı, 7 gün pil. Telefon bildirimleri.", 6),
            ("Mutfak Robotu 1000W", "Çok amaçlı doğrayıcı ve karıştırıcı. Paslanmaz çelik bıçak. Kolay temizlenen parçalar.", 7),
            ("Tencere Seti 6 Parça", "İndüksiyon uyumlu, ısıya dayanıklı. Yapışmaz iç yüzey. Kapaklı saklama.", 8),
            ("Yoga Matı 6mm", "Kaymaz taban, ekstra kalın. Doğal kauçuk, kokusuz. Taşıma askısı dahil.", 9),
            ("Kahve Makinesi Filtre", "1.25 litre kapasite, anti-damlama sistem. Otomatik kapanma. Kolay temizlenir.", 10),
            ("Çalışma Lambası LED", "Ayarlanabilir parlaklık, 3 mod. Göz yormayan ışık. USB şarj edilebilir.", 11),
            ("Dokunmatik Eldiven", "Akıllı telefon kullanımı için parmak uçları iletken. Soğuk hava için sıcak tutar.", 12),
            ("Pilates Topu 55cm", "Patlama önleyici, 300 kg taşıma kapasitesi. Fitness ve rehabilitasyon için.", 13),
            ("Mekanik Klavye RGB", "Cherry MX eşdeğer anahtarlar. Alüminyum gövde. Oyun ve ofis kullanımı.", 14),
            ("Kablosuz Mouse", "Ergonomik tasarım, 1600 DPI. Sessiz tıklama. 18 ay pil ömrü.", 15),
            ("Masaüstü Organizer", "Kalemlik, dosya bölmeleri, telefon tutucu. Minimal çelik tasarım.", 16),
            ("Su Geçirmez Cüzdan", "RFID blokajlı. 6 kart + banknot bölmesi. Ince ve dayanıklı.", 17),
            ("Güneş Gözlüğü Polarize", "UV400 koruma. Hafif çerçeve. Kırılmaz cam, çizilmeye dayanıklı.", 18),
            ("Spor Çantası 40L", "Su geçirmez bölme. Ayakkabı için ayrı alan. Omuz ve sırt taşıma.", 19),
            ("Termos 500ml", "12 saat sıcak, 24 saat soğuk. Paslanmaz çelik. Tek tuşla açılır kapak.", 20),
            ("Mum Seti 6'lı", "Soya mumu, uzun yanma süresi. Doğal esanslar. Dekoratif cam kavanoz.", 21),
            ("Duvar Saati Minimal", "Sessiz quartz mekanizma. Ahşap çerçeve. 30 cm çap.", 22),
            ("Yastık Seti 2'li", "Anti-alerjik elyaf dolgu. Yıkanabilir kılıf. Orta destek.", 23),
            ("Battaniye 140x200", "Yumuşak mikrofiber. Makinede yıkanabilir. Mevsimler arası kullanım.", 24),
            ("Şarjlı El Feneri", "LED, 3 mod (zayıf/güçlü/yanıp sönme). 6 saat pil. Su geçirmez.", 25),
            ("Masa Oyunu Strateji", "2-4 oyuncu. 45 dk oyun süresi. Tahta parçalı, dayanıklı kutu.", 26),
            ("Puzzle 1000 Parça", "Doğa manzarası. Baskı kalitesi yüksek. Tamamlandığında 68x48 cm.", 27),
            ("Okuma Lambası Klipsli", "Kitaplığa veya masaya takılır. 3 parlaklık seviyesi. USB ile şarj.", 28),
            ("Kalem Seti 12'li", "Döküm uç, akıcı yazım. Ofis ve öğrenci için. Çeşitli renkler.", 29),
            ("Not Defteri A5", "Çizgili, 120 yaprak. Sert kapak. El yazısı ve ofis için.", 30),
            ("Kablosuz Şarj Pedi", "Qi uyumlu, 10W hızlı şarj. Tek telefon. LED göstergeli.", 31),
            ("Powerbank 20000mAh", "Çift USB çıkış, hızlı şarj. Cep telefonu ve tablet uyumlu. Uçakta taşınabilir.", 32),
            ("Telefon Kılıfı Silikon", "Ekran koruyucu kenar. Şeffaf veya renkli. Tüm modeller için uyumlu.", 33),
            ("Ekran Koruyucu Cam", "Çizilmeye dayanıklı, yapışkanlı. Kurulum seti dahil. 9H sertlik.", 34),
            ("Laptop Standı Alüminyum", "Havalandırmalı, 6 açı ayarı. Taşınabilir, hafif. 11-17 inç uyumlu.", 35),
            ("USB Hub 4 Port", "USB 3.0, hızlı veri aktarımı. Kompakt tasarım. Plug and play.", 36),
            ("Webcam 1080p", "Otomatik odak, mikrofon dahil. Zoom ve stream için. Tripod adaptörlü.", 37),
            ("Kulaklık Askısı", "Masa kenarına takılır. Kablo düzenleyici. Çoğu kulaklık uyumlu.", 38),
            ("Masa Altı Dosya Sepeti", "Çekmeceli, 2 bölmeli. Ofis ve ev için. Kolay montaj.", 39),
            ("Ofis Koltuğu Mesh", "Bel desteği ayarlanabilir. 135 kg taşıma. 5 tekerlek, sessiz.", 40),
            ("Dik Durma Yastığı", "Araba ve ofis koltuğu için. Bel desteği. Yıkanabilir kılıf.", 41),
            ("Ayaklık Masası Altı", "Ayakları yukarı kaldırır. Ahşap üst. Nefes alan kumaş.", 42),
            ("Dosya Klasörü Seti", "A4 boyut, 5 renk. Etiket alanı. 10'lu paket.", 43),
            ("Zımba Makinesi", "20 sayfa kapasite. Metal gövde. Zımba teli dahil.", 44),
            ("Makas Seti 3'lü", "Ofis, ev, el işi. Paslanmaz çelik. Kılıflı.", 45),
            ("Bant Rulosu 6'lı", "Çeşitli genişlikler. Yırtılabilir. Ofis ve paketleme.", 46),
            ("Magnet Seti 50'li", "Buzdolabı ve whiteboard. Renkli. Güçlü yapışma.", 47),
            ("Suluk 750ml", "BPA free, çelik. Sızdırmaz kapak. Buz tutucu.", 48),
            ("Öğle Yemeği Kutusu", "3 bölmeli, mikrodalga uyumlu. Sızdırmaz kapak. Buz paketi dahil.", 49),
            ("Bebek Bezi Paketi", "Ekstra emici, 4-9 kg. Yumuşak yüzey. 48'li paket.", 50),
        };

        /// <summary>
        /// Index'e göre ürün verisi döner. Ürün sayısı listeden fazlaysa döngüsel kullanılır.
        /// </summary>
        public static (string Title, string Description, string CoverImageUrl) GetItem(int index)
        {
            var item = Items[index % Items.Length];
            var imageUrl = $"https://picsum.photos/id/{item.PicsumId}/800/600";
            return (item.Title, item.Description, imageUrl);
        }

        public static int DataCount => Items.Length;
    }
}
