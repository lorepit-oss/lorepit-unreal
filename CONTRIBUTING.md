# Contributing

## Building

```bash
"/Users/Shared/Epic Games/UE_5.8/Engine/Build/BatchFiles/RunUAT.sh" BuildPlugin \
  -Plugin="$PWD/Lorepit.uplugin" -Package="/tmp/Lorepit-Packaged" -TargetPlatforms=Mac -Rocket
```

(`RunUAT.bat … -TargetPlatforms=Win64` on Windows.)

## Tests

Today: the inherited Automation tests in `Source/LorepitSourceControlTests` (`Automation RunTests Lorepit`).

Coming, in four tiers, each run by `Tests/run-all.sh`:

1. **Unit**: UE Automation and Spec tests, pure.
2. **Integration**: a real `lore` against a local `lore-server`, for every command the plugin issues.
3. **End to end**: the full editor off-screen against that server: check out, save, check in, sync,
   revert, delete, add, branch switch.
4. **UI**: every menu, dialog and panel, through Slate widget queries.

A surface inventory (`Tests/Surface.json`) lists every operation, lore command, parser, setting and
UI element, and a meta-test fails when one has no test. New behaviour starts with a failing test.

## Changes

Every difference from upstream goes in [CHANGES.md](CHANGES.md). Generic fixes are offered upstream to
[Solessfir/LoreSourceControl](https://github.com/Solessfir/LoreSourceControl) as pull requests.
