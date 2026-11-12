# Changes from upstream

Upstream: [Solessfir/LoreSourceControl](https://github.com/Solessfir/LoreSourceControl), forked at
`b6cd42b` ("Remove Lore version warnings", 2026-10-05). Every way this fork differs is listed here,
newest first.

## Unreleased

### Reliability fixes (offered upstream: Solessfir/LoreSourceControl#2)

Each has a test that failed before it (`Lorepit.Process.*`, `Lorepit.State.*`, `Lorepit.Provider.*`,
`Lorepit.Status.*`, `Lorepit.Connect.*`, `Lorepit.Workers.CheckIn.KeepCheckedOutKeepsLocks`):

- **No lore call waits forever.** Every call runs with a deadline (30 s for quick reads up to 1,800 s
  for commit, push and sync), and a lore killed by a signal is a failed command instead of an editor
  crash (`check(bGotReturnCode)` in the engine's `ExecProcess`).
- **On Mac, arguments reach lore intact.** lore runs through `/bin/sh` as on Linux. Quotes in commit
  messages no longer split arguments, and a Check In of more than ~250 files no longer crashes the
  editor (the Mac launcher's 256-argument limit).
- **A modified file nobody else has locked counts as checked out,** so the Submit dialog no longer
  drops it silently (for example the `.uproject`).
- **States not read from lore are stale,** so the engine refreshes them after a save and Submit is
  enabled without a Sync.
- **A failed lock query keeps the status that succeeded.**
- **Connect and Sync scan Config and the project file,** not only Content.
- **"Keep files checked out" keeps the locks.**

Tooling: `Tools/run-tests.sh` (build, install into `Tests/HostProject`, run headless) and a fake-lore
test double.


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
