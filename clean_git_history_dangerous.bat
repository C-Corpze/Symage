pause
git checkout --orphan TEMP
git add -A
git commit -m "Initial"
git branch -D main
git branch -m main
git push -f origin main
pause