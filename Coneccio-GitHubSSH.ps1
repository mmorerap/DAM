Get-Service -Name ssh-agent | Set-Service -StartupType Automatic
Start-Service ssh-agent
ssh-add c:/Users/marcm/.ssh/id_ed25519
cd  "C:\Users\marcm\Desktop\AD_activitats"
code .