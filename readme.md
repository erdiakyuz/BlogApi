
### Projede kullanıdığınız tasarım desenleri hangileridir? Bu desenleri neden kullandınız?

Repository Pattern ve UnitOfWork kullandım. UoW context ve Repository yönetimini tekilleştirmek ve kolay yönetebilmek için kullanıldı. Repository yapısı itibariyle veriye erişimin ve yönetimin tek bir yerden yönetildiği bir desendir. Kod okunurluğu ve test edilebilirlik anlamında avantaj sağlar.

### Kullandığınız teknoloji ve kütüphaneler hakkında daha önce tecrübeniz oldu mu? Tek tek yazabilir misiniz?

.Net EF Core dışında tüm teknolojileri şu anda çalıştığım firmamda aktif olarak kullanmaktayım. .Net EF 6.x tecrübem olmuştu böylece .Net EF Core'a kolay adapte oldum.

### Daha geniş vaktiniz olsaydı projeye neler eklemek isterdiniz?

Pagination'a uygun Get yapıları, Global Exception Handling yapısını kullanmak, Utility bazındaki methodların gerekli overloadları, Güvenlik için Token ile haberleşme, Mapperların organizasyonu.

### Eklemek istediğiniz bir yorumunuz var mı? 
Proje locale çekilip migrate edilirse, Dummy data içeren Veritabanı oluşacaktır.
GitHub üzerinden adım adım commit istemişsiniz ancak ben onu atlamışım. Projenin geliştime ilerleyiş kronolojisi aşağıdaki gibidir.
```bash
Repository -> Utility -> API -> EF Configuration ve Mappings
