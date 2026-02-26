# Deploy SAMET Shop – Get a Live Link

To send someone a **link where the site actually runs** (not just code), you need to deploy the app. Below is a simple way using **Azure** (free tier possible).

---

## Option 1: Azure App Service (recommended for a demo link)

### 1. Create Azure account

- Go to [https://azure.microsoft.com/free/](https://azure.microsoft.com/free/)
- Sign up (free tier gives limited credits; App Service Free tier is available).

### 2. Create the app in Azure

1. Open [Azure Portal](https://portal.azure.com) → **Create a resource** → **Web App**.
2. Fill in:
   - **Subscription:** your subscription
   - **Resource group:** e.g. `samet-shop-rg`
   - **Name:** e.g. `samet-shop-demo` (this will be `samet-shop-demo.azurewebsites.net`)
   - **Publish:** Code
   - **Runtime:** .NET 8 (Windows or Linux)
   - **Region:** e.g. West Europe
   - **Pricing:** Free F1 (for demo) or Basic B1 if you prefer.
3. Click **Review + create** → **Create**.

### 3. Database for the demo

The app uses **SQL Server**. You have two options:

- **A) Azure SQL Database**  
  - Create an Azure SQL server + database in the portal.  
  - Copy the ADO.NET connection string and use it in the next step.

- **B) Keep using your own SQL Server**  
  - If your SQL Server is reachable from the internet (not recommended for production), you could use its connection string. For a quick demo, Azure SQL is simpler.

### 4. Set connection string in Azure

1. In Azure Portal, open your **Web App** → **Settings** → **Configuration**.
2. Under **Application settings**, add:
   - **Name:** `ConnectionStrings__shop`
   - **Value:** your SQL connection string (e.g. Azure SQL).
3. Save.

### 5. Deploy the code

**From Visual Studio:**

1. Right-click **UI_MVC** project → **Publish**.
2. Target: **Azure** → **Azure App Service (Windows)** (or Linux if you chose Linux).
3. Sign in and select the web app you created.
4. Publish. When it finishes, the site URL is:  
   `https://samet-shop-demo.azurewebsites.net` (replace with your app name).

**From command line (publish folder + ZIP deploy):**

```bash
cd UI_MVC
dotnet publish -c Release -o ./publish
# Then in Azure Portal: Web App → Deployment Center → ZIP Deploy, or use Azure CLI to upload ./publish.
```

**From GitHub (optional):**

1. Push this repo to GitHub.
2. In Azure Portal: Web App → **Deployment Center** → **GitHub** → authorize and select repo + branch.
3. Azure will build and deploy on each push.

### 6. Run migrations on the deployed database

After first deploy, the app needs the database schema. Either:

- Run migrations from your machine against the **Azure SQL** connection string, or  
- Use **EF Core migrations in startup** (you’d add a small code block that runs `context.Database.Migrate()` when the app starts in production).  
Then open your web app URL and test.

---

## Option 2: Only share the GitHub link

If you **don’t deploy** and only share the repo:

- **What they get:** Full source code; they can clone and run it locally (with .NET 8 + SQL Server).
- **What they don’t get:** A single “click and see” link. You can say:  
  *“There’s no live demo link yet; here’s the GitHub repo so you can run it locally: [link].”*

So:

- **GitHub link** = enough for **code** and “run on your machine”.
- **Live link** = need to **deploy** (e.g. Azure) as above; then you can send `https://your-app.azurewebsites.net`.

---

## Summary

| What you want to send   | What to do                                      |
|-------------------------|--------------------------------------------------|
| **Only code**           | Share GitHub repo link.                          |
| **Code + running site** | Deploy to Azure (or similar), then share both:   |
|                         | - GitHub: `https://github.com/Sameth1/E_TICARET` |
|                         | - Demo: `https://your-app.azurewebsites.net`      |

After deployment, you can tell your friend:  
*“Here’s the repo: [GitHub link]. And here’s the live demo: [Azure link].”*
