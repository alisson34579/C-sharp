Beleza 👇 resumo do início ao fim:

1. Parar containers:



docker stop $(docker ps -q)

2. Apagar containers:



docker rm -f $(docker ps -aq)

3. Rodar o Jellyfin:



docker run -d --name jellyfin -p 8096:8096 \
  -v ~/jellyfin/config:/config \
  -v ~/jellyfin/cache:/cache \
  -v ~/jellyfin/media:/media \
  jellyfin/jellyfin

4. Acessar no navegador:
http://localhost:8096


5. Criar usuários:



aluno / mpe

adm / admin123


6. Colocar vídeo na pasta:
~/jellyfin/media


7. Ver IP:
ipconfig (Windows) ou hostname -I (Linux)


8. Colega acessa:
http://seu_IP:8096



✅ Pronto, Jellyfin rodando no Docker e acessível na rede.

