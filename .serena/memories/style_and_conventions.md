# Style and conventions
- C# Unity MonoBehaviour scripts, many from decompiled/converted legacy UnityScript.
- Existing legacy scripts often use public fields for Inspector serialization and minimal/no comments.
- Preserve public field names and MonoBehaviour method names (`Start`, `Update`, etc.) to avoid breaking scene/prefab serialization.
- For Unity 6 migration, replace obsolete UnityScript/Boo generated coroutine scaffolding (`Boo.Lang.GenericGenerator`) with idiomatic C# `IEnumerator` coroutines using `yield return`.
- Prefer minimal surgical edits because the project has many old scripts and serialized Unity references may depend on names/types.