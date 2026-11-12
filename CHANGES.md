# Changes from upstream

Upstream: [Solessfir/LoreSourceControl](https://github.com/Solessfir/LoreSourceControl), forked at
`b6cd42b` ("Remove Lore version warnings", 2026-10-05). Every way this fork differs is listed here,
newest first.

## Unreleased

### Renamed, so it can never be confused with upstream in one editor

- Plugin `LoreSourceControl` → `Lorepit` (`Lorepit.uplugin`), friendly name **Lorepit**.
- Modules `LoreSourceControl` / `LoreSourceControlTests` → `LorepitSourceControl` /
  `LorepitSourceControlTests`; export macro `LOREPITSOURCECONTROL_API`.
- Revision-control provider name `Lore` → `Lorepit`. (`Provider=Lorepit` in a project's
  `SourceControlSettings.ini`.)
- Settings class `ULoreSourceControlSettings` → `ULorepitSourceControlSettings` (Project Settings →
  Plugins → **Lorepit Source Control**); its config section is `/Script/LorepitSourceControl.LorepitSourceControlSettings`.
- Editor command set `LoreSourceControl` → `LorepitSourceControl`, and the branch-menu Slate styles
  likewise.
- Automation tests `LoreSourceControl.*` → `Lorepit.*`.
- The plugin descriptor credits upstream and drops the Fab listing URL (that listing is upstream's).

Internal C++ class names (`FLoreSourceControlProvider` and so on) are upstream's, unchanged, to keep
this fork's diff small and its fixes easy to offer upstream.

The one-time migration of upstream's old `Saved/Config/LoreSourceControl.ini` is kept as it was.
