# Suggested commands
- Use Unity Editor 6000.4.10f1 to compile/import the project; the most reliable validation is Unity's Console after asset refresh.
- Inspect git state: `git --no-pager status --short`
- Inspect changes: `git --no-pager diff -- Assets/Scripts/Assembly-UnityScript/FireFade.cs`
- Search code from shell if needed: `grep -R "Boo.Lang" Assets/Scripts`
- No standalone test/build command was identified from the project files; Unity Test Framework is present in `Packages/manifest.json`, so tests (if any) should be run from Unity Test Runner or Unity batchmode once configured.