@echo off
rem
echo [GIT] Adding everything...
git add .

echo [GIT] Committing to git as %date:/=% %time:/=%...
git commit -m "%date:/=% %time:/=%"

echo [GIT] Pushing to git...
git push

echo [GIT] Done!

pause
cls
exit