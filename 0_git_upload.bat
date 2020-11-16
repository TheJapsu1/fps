rem
echo Adding everything...
git add .

echo Committing to git...
git commit -m "%date:/=% %time:/=%"

echo Pushing to git...
git push

echo Done!

pause
cls
exit