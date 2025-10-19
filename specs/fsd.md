# 🧭 Functional Specification Document  
## Project: D&D Adventure Generator  
**Version:** 0.1 (Initial Specification)  
**Author:** Tijmen van der Hilst  
**Date:** 2025-10-19  

---

## 1. Overview  

### 1.1 Purpose  
The D&D Adventure Generator is an AI-assisted tool designed to create detailed Dungeons & Dragons adventures comparable in quality and structure to official published modules. It leverages structured campaign context files and curated system prompts to produce coherent, lore-consistent, and narratively rich adventure content.  

### 1.2 Goals  
- Automate generation of D&D adventures consistent with campaign context.  
- Maintain coherence across acts, storylines, and player backgrounds.  
- Produce outputs usable by DMs as written material or for further editing.  
- Support modular expansion (e.g. quest hooks, maps, stat blocks, etc.).  

### 1.3 Target Users  
- Dungeon Masters seeking AI assistance in adventure design.  
- Writers and worldbuilders managing long-running homebrew campaigns.  
- Game developers or LLM-based systems integrating story generation pipelines.  

---

## 2. System Components  

### 2.1 Core Inputs  
| Component | Description | Format / Example |
|------------|--------------|------------------|
| **System Prompt** | Defines tone, structure, and quality expectations (e.g., “Write a D&D 5e adventure in the style of *Candlekeep Mysteries*”). | Text template (Markdown/JSON) |
| **Campaign Context File** | Encapsulates all campaign-relevant information: setting, factions, tone, major arcs. | JSON or YAML |
| **Story So Far** | Summarized narrative of previous sessions or acts. | Plain text / Markdown |
| **Premise** | High-level adventure idea (hook, main conflict, location). | Text |
| **Party File** | Contains PC data: name, race, class, backstory, motivations, relationships. | JSON or Markdown table |
| **Existing Adventure File (optional)** | For extending or revising previous adventures. | Text / Markdown |

---

### 2.2 Core Outputs  
| Output | Description | Format |
|---------|--------------|--------|
| **Adventure Document** | A fully written adventure including acts, scenes, NPCs, and encounters. | Markdown / PDF |
| **Summary / Outline** | A concise overview for quick DM reference. | Markdown |
| **Metadata File** | Structured data about generated content (themes, level range, tone, tags). | JSON |

---

## 3. Functional Requirements  

### 3.1 Input Handling  
- The application can **load multiple context files** (system prompt, campaign, party, etc.) and merge them into a single prompt payload.  
- The user can **select which components** to include (e.g., only premise + story so far).  
- The system should validate file formats (basic schema check).  
- Optional: auto-suggest missing components (e.g., “No party file found, create sample party?”).  

### 3.2 Adventure Generation  
- The system generates an adventure with:  
  - **Acts / Chapters** (3–5 segments typical of D&D modules)  
  - **Major NPCs** with motives and dialogue hooks  
  - **Encounters** (combat, exploration, roleplay)  
  - **Locations** with descriptive text and possible events  
  - **Rewards / Consequences** tied to choices and PC backstories  
- Adventures should be **consistent** with prior context and **scalable** to party level.  
- Generation should be **deterministic** if a fixed seed or versioning mode is used.  

### 3.3 Adventure Structure (Baseline Template)  
Each adventure includes:  
1. **Title & Overview** – name, level range, and summary.  
2. **Adventure Hook** – reason to start the story.  
3. **Background** – relevant lore or prior events.  
4. **Act Structure** – divided into acts/scenes with clear goals.  
5. **Key NPCs and Factions.**  
6. **Notable Locations and Challenges.**  
7. **Resolution / Aftermath.**  

### 3.4 Output Features  
- Export options:  
  - Markdown (for editing)  
  - PDF (for distribution)  
- Optional compression of long text sections (e.g., “DM Summary Mode”).  
- Version tracking for iterations (e.g., v1.0, v1.1).  

### 3.5 Session Continuity  
- The system can append new adventures to an existing campaign timeline.  
- Maintains internal references (NPC continuity, unresolved threads).  
- Optional feature: *Adventure Chaining* – uses “Adventure End State” as next “Story So Far”.  

---

## 4. Non-Functional Requirements  

| Category | Description |
|-----------|--------------|
| **Performance** | Generate an adventure (3–5 acts) within 60 seconds for standard prompts. |
| **Reliability** | Handle malformed or incomplete inputs gracefully. |
| **Scalability** | Designed for modular expansion (e.g., stat generation, maps). |
| **Usability** | Clear CLI or GUI flow for selecting context files and output options. |
| **Extensibility** | Support for plugins (custom prompt templates, world settings). |

---

## 5. Architecture Overview  

### 5.1 Logical Flow

[User Input]
↓
[File Parser & Validator]
↓
[Prompt Assembler]
↓
[LLM Engine / Adventure Generator]
↓
[Formatter & Metadata Extractor]
↓
[Output (Markdown / PDF / JSON)]

### 5.2 Suggested Modules  
| Module | Responsibility |
|--------|-----------------|
| **Context Manager** | Load, validate, and merge campaign context files. |
| **Prompt Builder** | Combine templates and context into a structured LLM prompt. |
| **Adventure Generator** | Interface with LLM or text generation backend. |
| **Post-Processor** | Format raw text into structured adventure sections. |
| **Exporter** | Save and export adventure documents. |
| **Version Manager (optional)** | Handle revisions and continuity across sessions. |

---

## 6. Initial User Interface (CLI / Minimal GUI)  

**Main Menu:**  
1. Create New Adventure  
2. Continue Existing Campaign  
3. Edit Context Files  
4. Export / View Adventure  

**Adventure Creation Flow:**  
1. Select or import context files  
2. Review merged context summary  
3. Choose adventure level and theme  
4. Generate adventure  
5. Review and export  

---

## 7. Future Extensions (Placeholder)  
These are potential features for later phases:  
- Encounter stat generation (monsters, CR scaling).  
- Visual map or region generator.  
- DM tools: pacing notes, random events.  
- Integration with VTTs (e.g. Foundry, Roll20).  
- Persistent world memory across multiple campaigns.  

---

Would you like me to extend this spec next toward **implementation-level details** (e.g., data schemas and file structures), or toward **user workflow & UX specifications** (menus, flow, interaction logic)?
