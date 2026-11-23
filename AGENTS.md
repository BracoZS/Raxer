# Raxer

App indie de remapeo del mouse con funciones útiles para Windows.
Código artisan, sin arquitecturas impuestas (nada de clean, hexagonal, CQRS); organizado en `Modules/` e `Infra/`.

## Al iniciar sesión

1. Lee `.agents/STATUS.md`. Siempre: es corto y dice dónde nos quedamos.
2. Lee solo lo que la tarea necesite usando esta tabla.
3. Nunca leas `.agents/LOG.md` completo. Si necesitas historia, lee solo las primeras 20 líneas.

| Necesitas | Lee |
|---|---|
| Trabajar en una feature | `.agents/specs/<feature>.md` (usa `.agents/specs/_TEMPLATE.md` para nuevas) |
| Escribir código o correr comandos | `.agents/STACK.md` |
| Saber qué entra y qué queda fuera | `.agents/PROJECT.md` |
| Ver foco actual y qué sigue | `.agents/ROADMAP.md` |
| Proponer cambio de arquitectura o stack | `.agents/DECISIONS.md` |

## Reglas de trabajo

- Trabaja solo en el foco actual (`← CURRENT` en `.agents/ROADMAP.md`). Nada de Next, Later o "Do not touch yet" en `.agents/STATUS.md`.
- Una tarea por sesión. Lo fuera de scope anótalo en "Next" de `.agents/STATUS.md` y sigue.
- No hablar como cotorra. Si falta info para decidir, pregunta; no asumas.
- Pregunta antes de decisiones de arquitectura, stack o scope, y regístralas en `.agents/DECISIONS.md`.
- No hacer build sin permiso del developer.
- Sin dependency injection. Sin interfaces de adorno. Módulos usan `Infra` libremente.
- Idioma: spanglish (inglés/español con normalidad). Nunca escribir secretos en `.agents/`.
- **Recursos (.resx)**: keys en kebab-case (`menu-start-with-windows`). Inglés neutral (`Resources.resx`), español (`Resources.es.resx`). Presentar siempre en tabla única: Key / English / Español.

## Guardar estado y cerrar sesión

No actualices `.agents/` tras cambios pequeños o iteraciones en curso. Actualiza solo cuando:
- El usuario diga "cerrar sesión" / "guardar estado".
- Justo antes de un commit (si el usuario pide commitear).
- Se complete el foco actual (o un criterio `Done when`) o se cambie de tarea.

Si hubo avance grande pero el usuario puede seguir iterando, pregunta en una línea: "¿Actualizo `.agents/`?"

Al actualizar:
1. Sobrescribe `.agents/STATUS.md` con el estado real (máx. 40 líneas).
2. Agrega arriba en `.agents/LOG.md` (`## YYYY-MM-DD (hh:mm am/pm) — <título>`, 12h).
3. Si hubo decisiones, añádelas al final de `.agents/DECISIONS.md`.
4. Si algo quedó descartado, añádelo a "Out of scope" en `.agents/PROJECT.md`.
5. Actualiza `.agents/ROADMAP.md` (marca completado y promueve si terminó el foco).
6. Responde con un resumen de 3 líneas máximo.

## Skills

| Tarea | Skill |
|---|---|
| Reglas globales y estilo de sesión | `general` |
| Migrar o escribir código .NET 11 / C# 15 | `dotnet-11` |
| Features modernas de C# 13-15 y .NET 10/11 | `dotnet-csharp` |
| Escribir, limpiar o refactorizar código KISS | `kiss-code-style` |
| Generar mensajes de commit | `caveman-commit` |
| Capturar notas, ideas o decisiones sin tocar código | `notas-jarvis` |
