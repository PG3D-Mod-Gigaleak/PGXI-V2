# Task completion checklist
- For script edits, let Unity refresh/recompile and check Console errors.
- Run focused searches to verify removed legacy references when applicable (e.g. `Boo.Lang`, `GenericGenerator`).
- If using terminal, inspect `git --no-pager diff` before final summary.
- Report any remaining migration errors separately; avoid fixing unrelated Unity 6 issues unless requested.