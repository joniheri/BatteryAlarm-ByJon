## System Requirement:

- Open sourcecode wiht Visual Studio 2026 or Lates: Community Version
- .NET 10.0

## Make Release at GitHub

### Step 1 - Make Tag version

in terminal:

```bash
git tag v1.0.0
git push origin v1.0.0
```

Description

```
v1.0.0
↑
ini penanda source code untuk release
```

Setelah selesai, GitHub akan tahu bahwa ada versi baru.

### Langkah 2 — Buka repository GitHub

Masuk ke repository Anda.

Di bagian kanan biasanya ada:

```
Releases
No releases published
```

click

```
Releases
→ Create a new release
```

Kalau tidak ada:

```
Code
→ Releases
→ Draft a new release
```

### Langkah 3 — Isi informasi Release

Isi seperti ini:

Tag

```
v1.0.0
```

Release title

```
Battery Alarm v1.0.0
```

Description

```
Battery Alarm v1.0.0

Features:
- Battery low notification
- Battery full notification
- Snooze notification
- Stop notification
- Run in background
- Run at startup
- System tray support
- Portable version

Technology:
- C#
- WinForms
- OOP Architecture
```

### Langkah 4 — Upload file portable

Di bawah ada area:

```
Attach binaries by dropping them here
```

Drag file:

```
BatteryAlarm-ByJon-v1.0.0-portable.zip
```

or click:

```
Upload files
```

choose:

```
your-directory\BatteryAlarm-ByJon-v1.0.0-portable.zip
```

Wait upload finish.

Done.

Hasilnya nanti kira-kira seperti ini:

```
Battery Alarm v1.0.0

Assets

BatteryAlarm-ByJon-v1.0.0-portable.zip
```

Dan link download otomatis menjadi:

```
https://github.com/USERNAME/BatteryAlarm-ByJon/releases
```
