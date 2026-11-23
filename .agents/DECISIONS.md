# Decisions

Append-only. Una entrada por decisión. Si una decisión se revierte, no la borres: cambia su status y agrega una entrada nueva.

## D-001: Migrar target framework a .NET 11 (2026-11-23)
- Decision: Actualizar el proyecto de `net10.0-windows` a `net11.0-windows`.
- Reason: Mantener la app al día con .NET 11 antes de continuar con nuevas features.
- Alternatives discarded: Mantenerse en `.NET 10`.
- Status: active
