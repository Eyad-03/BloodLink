# BloodLink — Frontend + Database (بدون Backend)

نسخة من مشروع BloodLink فيها **الواجهات (Frontend)** و**قاعدة البيانات (Database)** فقط، زي ما هي بدون أي تعديل.
الـ Backend (الـ API) مش موجود — جاهز إنك تبنيه.

## التشغيل في Visual Studio

1. ثبّت SQL Server Express (الـ connection string موجود في `BloodLink/appsettings.json`).
2. افتح `BloodLink.sln` في Visual Studio 2026 (‎.NET 10).
3. اضغط **F5**.

عند التشغيل البرنامج بيعمل الداتابيس تلقائياً (`Database.Migrate()`) وبيضيف بيانات تجريبية (`Data/DbInitializer.cs`).
أو بتقدر تنشئ الداتابيس يدوياً من SQL Server Management Studio بتشغيل `Database/BloodLink.sql`.

## شو موجود

```
BloodLink.sln
Database/BloodLink.sql      سكربت SQL كامل لإنشاء قاعدة البيانات (من الـ migrations)
BloodLink/
  Views/                    صفحات الموقع (.cshtml)
  wwwroot/css, js, images   التصاميم والجافاسكربت
  Controllers/              Controllers الصفحات فقط (كل واحد بيرجّع View)
  Models/Entities/          جداول قاعدة البيانات
  Data/                     BloodLinkDbContext + Migrations + بيانات تجريبية
  Program.cs                إعداد بسيط: MVC + قاعدة البيانات
```

## شو مش موجود (الـ Backend اللي رح تبنيه)

- `Controllers/Api/` — كل الـ API (`/api/auth`, `/api/requests`, `/api/donors`, ...)
- `Models/Dtos/`
- `Helpers/` (JWT, Email, Upload, ...)
- إعدادات JWT / Google / Stripe / Email في `appsettings.json`

ملفات الجافاسكربت (مثل `wwwroot/js/api.js`) لسا بتنادي على `/api/...`، فالصفحات رح تفتح
بس البيانات ما رح تشتغل لحد ما تبني الـ API.
