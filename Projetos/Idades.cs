docker run -d --name jellyfin -p 8096:8096 \
  -v ~/jellyfin/config:/config \
  -v ~/jellyfin/cache:/cache \
  -v ~/jellyfin/media:/media \
  --restart unless-stopped \
  linuxserver/jellyfin