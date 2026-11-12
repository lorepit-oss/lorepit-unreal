# Lorepit for Unreal Engine

An Unreal Engine plugin for [lore](https://github.com/EpicGames/lore) revision control, maintained by
[lorepit](https://lorepit.com), with lorepit's features coming to the editor.

**It is a fork of [Lore Source Control](https://github.com/Solessfir/LoreSourceControl) by Solessfir
(Constantine Romakhov), MIT-licensed.** The upstream history is kept in full, and the original
licence is unchanged in [LICENSE](LICENSE). See [NOTICE.md](NOTICE.md) for the credit, and
[CHANGES.md](CHANGES.md) for every way this fork differs from upstream.

> **Status: pre-release.** The fork has just been made. Until the first release it behaves as upstream
> does, under new names. The roadmap is below.

## Why a fork

lorepit hosts lore repositories, and its Hub opens Unreal projects ready to use. We want a plugin we
can test exhaustively, fix on our own schedule, sign, and ship through the Hub:

- **Reliability.** Every lore call gets a time limit, a killed `lore` no longer crashes the editor, and
  deletes, check-outs with locking off, and lock release on failed check-ins all work.
- **lorepit in the editor.** FYI articles for the selected asset, Yap coordination and lock-release
  requests, locks, history and change requests, through the lorepit CLI (`lorepit mcp`), so this
  plugin never handles lorepit credentials itself.
- **Signed releases through the Hub.** The Hub installs a signed build into the project, and switches
  off the upstream plugin so the editor never shows two Lore providers.

Fixes that aren't lorepit-specific are offered back upstream.

## Supported platforms

- macOS (first)
- Windows
- Linux (as upstream; not yet tested by us)

## Features (inherited from upstream)

- **Sync**: pull latest (`lore sync`) from the toolbar dropdown, with progress and completion feedback.
- **Commit**: stages and commits in one step, then pushes when a remote is configured.
- **Lock / Unlock**: advisory file locking (`lore lock acquire` / `lore lock release`).
- **Branch switching**: a dropdown next to the Revision Control icon, with unsaved-work protection.
- **File history**: revision browsing, diffing, and "Diff Against Depot".
- **Status tracking**: live Content Browser and asset-dialog icons.
- **Revert / Add / Delete**.

## Requirements

- The `lore` CLI, on your `PATH`, at a path set in Project Settings, or installed by the lorepit Hub
  or CLI (`lorepit setup`).
- A lore repository: a `.lore` folder in the Unreal project folder or one of its parents, with an
  identity for commits and a remote for sync, push and locks.
- Unreal Engine 5.8. A plugin build only loads in the engine version it was built for.

## Installing

Once releases exist, the lorepit Hub's **Open in Unreal** installs and enables the plugin for you.
Until then, build it from source:

```bash
git clone https://github.com/lorepit-oss/lorepit-unreal.git
# macOS
"/Users/Shared/Epic Games/UE_5.8/Engine/Build/BatchFiles/RunUAT.sh" BuildPlugin \
  -Plugin="$PWD/lorepit-unreal/Lorepit.uplugin" -Package="$PWD/Lorepit-Packaged" -TargetPlatforms=Mac -Rocket
```

On Windows use `RunUAT.bat` and `-TargetPlatforms=Win64`. Copy the packaged folder into your
project's `Plugins/Lorepit`.

**Don't enable this and upstream's Lore Source Control in the same project.** Use one or the other.

## Getting started

1. **Revision Control** (bottom right of the main editor window) → **Connect to Revision Control...**
2. **Provider** → **Lorepit**.
3. The `lore` path auto-detects if lore is installed.
4. **Accept Settings**. A branch and actions dropdown appears next to the Revision Control icon.

## Configuration

**Project Settings → Plugins → Lorepit Source Control**:

- **Lore Path**: override the `lore` binary. Leave empty to auto-detect.
- **Use Lore Locks On Check Out**: acquire advisory lore locks during Check Out. Files stay editable;
  locks are released after submit or revert.

## Console commands

- **`LoreSync`**: a lore sync (pull), then a status update.
- **`LoreStatus`**: refreshes status and prints lore's status to the log.
- **`LoreCommit`**: opens the Submit Files dialog.

## Tests

The `LorepitSourceControlTests` editor module holds the parser, worker, provider and native lore tests,
inherited from upstream. Run the `Lorepit` group:

```text
UnrealEditor-Cmd <YourProject>.uproject -unattended -nullrhi -ExecCmds="Automation RunTests Lorepit" -TestExit="Automation Test Queue Empty"
```

Set `LORE_TEST_REMOTE` to a fresh repository URL on a disposable lore server to enable the remote
submit test. See [CONTRIBUTING.md](CONTRIBUTING.md) for how the test tiers are growing.

## Licence

MIT. See [LICENSE](LICENSE) (upstream's, unchanged) and [NOTICE.md](NOTICE.md). The plugin talks to a
separately installed `lore` binary; lore is MIT-licensed under its own terms.
