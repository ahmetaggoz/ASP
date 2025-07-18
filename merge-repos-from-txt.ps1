# Ayarlar
$MonorepoPath = "C:\Users\ahmet\Desktop\Is\ASP"  # Klonladığın ASP repo yolu
$RepoListFile = "C:\Users\ahmet\Desktop\\Is\ASP\repos.txt"  # URL listesi

# ASP monorepo klasörüne git
Set-Location -Path $MonorepoPath

# Repo.txt dosyasındaki her satır için işle
Get-Content $RepoListFile | ForEach-Object {
    $repoUrl = $_.Trim()
    if ($repoUrl -eq "") { return }  # boş satırı atla

    # Repo adını URL'den çıkar (son kısım, .git'siz)
    $repoName = [System.IO.Path]::GetFileNameWithoutExtension($repoUrl)

    Write-Host "`n➡️ İşleniyor: $repoName"

    # Remote ekle
    git remote add $repoName $repoUrl
    git fetch $repoName

    # Subtree olarak ekle
    git subtree add --prefix=$repoName $repoName main

    # Remote kaldır
    git remote remove $repoName
}

Write-Host "`n✅ Tüm repolar başarıyla ASP monoreposuna eklendi!"
