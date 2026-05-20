## System Requirements

- Open the source code with Visual Studio 2022 Community Edition or latest.
- .NET 8.0

## To DO

- Make Grafik history
- Jika sudah ceklis "Run at Startup" dan laptop di restar, maka program tidak perlu muncul dulu, tapi sudah running di Background!

## Make a Release on GitHub

### Step 1 - Create a version tag

In the terminal:

```bash
git tag v1.0.0
git push origin v1.0.0
```

explanation:

```text
v1.0.0
↑
This marks the source code version for the release
```

After that, GitHub will recognize that a new version is available.

### Step 2 - Open the GitHub repository

Open your GitHub repository.

On the right side, you will usually see:

```text
Releases
No releases published
```

Click:

```text
Releases
-> Create a new release
```

If that option is not shown, go to:

```text
Code
-> Releases
-> Draft a new release
```

### Step 3 - Fill in the release information

Use the following values:

Tag:

```text
v1.0.0
```

Release title:

```text
Battery Alarm v1.0.0
```

Example description:

```text
Battery Alarm v1.0.0

Features:
- Battery low notification
- Battery full notification
- Snooze notification
- Stop notification
- Runs in the background
- Runs at startup
- System tray support
- Portable version

Technology:
- C#
- WinForms
- OOP architecture
```

### Step 4 - Upload the portable file

Below, there is an area like this:

```text
Attach binaries by dropping them here
```

Drag this file into that area:

```text
BatteryAlarm-ByJon-v1.0.0-portable.zip
```

Or click:

```text
Upload files
```

Then select:

```text
your-directory\BatteryAlarm-ByJon-v1.0.0-portable.zip
```

Wait until the upload is complete.

Done.

The result will look something like this:

```text
Battery Alarm v1.0.0

Assets

BatteryAlarm-ByJon-v1.0.0-portable.zip
```

The download page link will automatically be:

```text
https://github.com/USERNAME/BatteryAlarm-ByJon/releases
```
